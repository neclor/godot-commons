using Godot;
using NeclorCommons.Components.Interfaces;
using NeclorCommons.Utils;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class Rotation2DComponent : Node2D, IComponent {


	[Signal]
	public delegate void DesiredRotationReachedEventHandler();


	public enum RotationMode {
		Lerp,
		Linear,
		Disabled,
	}


	[ExportGroup("")]
	[Export]
	public RotationMode Mode { get; set; } = RotationMode.Disabled;


	[ExportGroup("Rotation Speed")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float RotationSpeed {
		get;
		set => field = MathF.Max(0, value);
	} = MathF.PI / 2;

	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float Decay {
		get;
		set => field = MathF.Max(0, value);
	} = 20.0f;


	public float DesiredRotation {
		get;
		set => field = MathfUtils.WrapAngle(value);
	} = 0.0f;
	public float GlobalDesiredRotation {
		get {
			Node? parent = GetParent();
			if (parent is null || parent is not Node2D parentNode2D) return DesiredRotation;
			return MathfUtils.WrapAngle(parentNode2D.GlobalRotation + DesiredRotation);
		}
		set {
			Node? parent = GetParent();
			if (parent is null || parent is not Node2D parentNode2D) {
				DesiredRotation = value;
			} else {
				DesiredRotation = value - parentNode2D.GlobalRotation;
			}
		}
	}


	public bool IsAtDesiredRotation => Mathf.IsEqualApprox(Rotation, DesiredRotation);


	public override void _Ready() {
		DesiredRotation = Rotation;
	}

	public override void _PhysicsProcess(double delta) {
		if (IsAtDesiredRotation) return;
		switch (Mode) {
			case RotationMode.Lerp:
				Rotation = MathfUtils.WrapAngle(Mathf.LerpAngle(Rotation, DesiredRotation, MathfUtils.DecayWeight(Decay, (float)delta)));
				break;

			case RotationMode.Linear:
				Rotation = MathfUtils.WrapAngle(Mathf.RotateToward(Rotation, DesiredRotation, RotationSpeed * (float)delta));
				break;

			case RotationMode.Disabled:
				return;

			default:
				return;
		}

		if (IsAtDesiredRotation) EmitSignal(SignalName.DesiredRotationReached);
	}

	public void DesiredRotationLookAt(Vector2 globalPoint) {
		GlobalDesiredRotation = GlobalPosition.AngleToPoint(globalPoint);
	}

	#region Setters
	public void SetRotationMode(RotationMode mode) {
		Mode = mode;
	}

	public void SetRotationSpeed(float speed) {
		RotationSpeed = speed;
	}

	public void SetDecay(float decay) {
		Decay = decay;
	}

	public void SetDesiredRotation(float rotation) {
		DesiredRotation = rotation;
	}

	public void SetGlobalDesiredRotation(float globalRotation) {
		GlobalDesiredRotation = globalRotation;
	}
	#endregion
}
