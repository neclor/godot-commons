using Godot;
using NeclorCommons.Components.Interfaces;


namespace NeclorCommons.Components.Scenes;


[GlobalClass]
public partial class Camera2DSceneComponent : Camera2D, IScene, IComponent {


	public static string ScenePath => "res://addons/NeclorCommons/src/Components/Scenes/Camera/Camera2DSceneComponent.tscn";


	[ExportGroup("")]
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


	public override void _Process(double delta) {
		if (!Enabled) return;

		Vector2 halfViewportSize = GetViewportRect().Size / 2;
		Vector2 localMousePosition = GetViewport().GetMousePosition() - halfViewportSize;
		Vector2 normalizedMousePosition = localMousePosition.Clamp(-halfViewportSize, halfViewportSize) / (halfViewportSize * Zoom);

		Vector2 normalizedCameraPosition = new Vector2(
			MathF.Min(MouseDragLeftMargin + normalizedMousePosition.X, 0.0f) + MathF.Max(0.0f, normalizedMousePosition.X - MouseDragRightMargin),
			MathF.Min(MouseDragTopMargin + normalizedMousePosition.Y, 0.0f) + MathF.Max(0.0f, normalizedMousePosition.Y - MouseDragBottomMargin)
		);

		Position = normalizedCameraPosition * halfViewportSize;
	}

	public override void _UnhandledInput(InputEvent @event) {
		if (@event.IsActionPressed("scroll_up")) ZoomIn();
		else if (@event.IsActionPressed("scroll_down")) ZoomOut();

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
}
