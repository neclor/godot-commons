using Godot;
using Neclor.Commons.Utils;
using Neclor.Commons.Components.Interfaces;


namespace Neclor.Commons.Components.Scenes;


[GlobalClass]
public partial class Camera2DSceneComponent : Camera2D, IScene, IComponent {


	public static string ScenePath =>
		"res://addons/NeclorCommons/src/Components/Scenes/Camera/Camera2DSceneComponent.tscn";


	[Signal]
	public delegate void ShakeStartedEventHandler();
	[Signal]
	public delegate void ShakeFinishedEventHandler();


	[ExportGroup("Zoom")]
	[Export]
	public Vector2 MaxZoom {
		get;
		set => field = value.Max(MinZoom);
	} = new Vector2(2, 2);

	[Export]
	public Vector2 MinZoom {
		get;
		set => field = value.Clamp(Vector2.One * 0.001f, MaxZoom);
	} = Vector2.One;


	[ExportGroup("Mouse Drag", "MouseDrag")]
	[Export(PropertyHint.Range, "0, 1, 0.01")]
	public float MouseDragLeftMargin {
		get;
		set => field = Math.Clamp(value, 0.0f, 1.0f);
	} = 0.5f;

	[Export(PropertyHint.Range, "0, 1, 0.01")]
	public float MouseDragTopMargin {
		get;
		set => field = Math.Clamp(value, 0.0f, 1.0f);
	} = 0.5f;

	[Export(PropertyHint.Range, "0, 1, 0.01")]
	public float MouseDragRightMargin {
		get;
		set => field = Math.Clamp(value, 0.0f, 1.0f);
	} = 0.5f;

	[Export(PropertyHint.Range, "0, 1, 0.01")]
	public float MouseDragBottomMargin {
		get;
		set => field = Math.Clamp(value, 0.0f, 1.0f);
	} = 0.5f;

	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float MouseDragDecay {
		get;
		set => field = MathF.Max(0, value);
	} = 20.0f;


	[ExportGroup("Shake")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float DefaultShakeStrength {
		get;
		set => field = MathF.Max(0, value);
	} = 5.0f;

	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float ShakeDecay {
		get;
		set => field = MathF.Max(0, value);
	} = 5.0f;


	public float ShakeStrength {
		get;
		set => field = MathF.Max(0, value);
	} = 0.0f;


	public override void _Process(double delta) {
		if (!Enabled) return;

		ProcessPosition(delta);
		ProcessShake(delta);
	}


	public void StartShake(float? strength = null) {
		ShakeStrength = strength ?? DefaultShakeStrength;
		EmitSignal(SignalName.ShakeStarted);
	}

	public void ZoomIn() {
		Zoom = (Zoom * 1.1f).Min(MaxZoom);
	}

	public void ZoomOut() {
		Zoom = (Zoom / 1.1f).Max(MinZoom);
	}

	public void SetZoomToMax() {
		Zoom = MaxZoom;
	}

	public void SetZoomToMin() {
		Zoom = MinZoom;
	}

	#region Setters
	public void SetMaxZoom(Vector2 value) {
		MaxZoom = value;
	}

	public void SetMinZoom(Vector2 value) {
		MinZoom = value;
	}
	#endregion


	private void ProcessPosition(double delta) {
		Vector2 halfViewportSize = GetViewportRect().Size / 2;
		Vector2 localMousePosition = GetViewport().GetMousePosition() - halfViewportSize;
		Vector2 normalizedMousePosition = (localMousePosition / halfViewportSize).Clamp(-1, 1);

		Vector2 normalizedCameraPosition = new Vector2(
			MathF.Min(MouseDragLeftMargin + normalizedMousePosition.X, 0.0f) + MathF.Max(0.0f, normalizedMousePosition.X - MouseDragRightMargin),
			MathF.Min(MouseDragTopMargin + normalizedMousePosition.Y, 0.0f) + MathF.Max(0.0f, normalizedMousePosition.Y - MouseDragBottomMargin)
		);


		Position = Position.Lerp(
			normalizedCameraPosition * halfViewportSize / Zoom,
			MathfUtils.DecayWeight(MouseDragDecay, delta)
		);
	}

	private void ProcessShake(double delta) {
		if (Mathf.IsZeroApprox(ShakeStrength)) return;

		Vector2 offset = new Vector2(
			(float)GD.RandRange(-1.0f, 1.0f),
			(float)GD.RandRange(-1.0f, 1.0f)
		).Normalized() * ShakeStrength;
		Position += offset;
		ShakeStrength = float.Lerp(ShakeStrength, 0, MathfUtils.DecayWeight(ShakeDecay, delta));

		if (Mathf.IsZeroApprox(ShakeStrength)) EmitSignal(SignalName.ShakeFinished);
	}
}
