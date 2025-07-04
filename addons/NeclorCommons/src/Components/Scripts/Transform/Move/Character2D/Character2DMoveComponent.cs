using Godot;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class Character2DMoveComponent : MoveComponent {


	public enum RigidBodyPushMode {
		Force,
		Instant,
		Disabled,
	}


	[ExportGroup("")]
	[Export]
	public CharacterBody2D? Character { get; set; } = null;


	[ExportGroup("Speed")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float Speed {
		get;
		set => field = MathF.Max(0, value);
	} = 128.0f;

	[Export(PropertyHint.Range, "0, 100, 1, or_greater, hide_slider")]
	public float Decay {
		get;
		set => field = MathF.Max(0, value);
	} = 20.0f;


	[ExportGroup("Physics")]
	[Export(PropertyHint.Range, "0.001, 100, 0.001, or_greater, exp")]
	public float Mass {
		get;
		set => field = MathF.Max(0.001f, value);
	} = 1.0f;

	[Export]
	public RigidBodyPushMode PushMode { get; set; } = RigidBodyPushMode.Disabled;

	[Export(PropertyHint.Range, "0, 100, 0.001, or_greater")]
	public float ForceScale {
		get;
		set => field = MathF.Max(0, value);
	} = 1.0f;

	protected Vector2 Force { get; set; } = Vector2.Zero;


	public void ApplyCentralForce(Vector2 force) {
		Force += force;
	}

	public void ApplyCentralImpulse(Vector2 impulse) {
		Character?.Velocity += impulse / Mass;
	}

	#region Setters
	public void SetCharacter(CharacterBody2D? character) {
		Character = character;
	}

	public void SetSpeed(float speed) {
		Speed = speed;
	}

	public void SetDecay(float decay) {
		Decay = decay;
	}

	public void SetMass(float mass) {
		Mass = mass;
	}

	public void SetPushMode(RigidBodyPushMode pushMode) {
		PushMode = pushMode;
	}

	public void SetForceScale(float forceScale) {
		ForceScale = forceScale;
	}
	#endregion


	protected void ResetForce() {
		Force = Vector2.Zero;
	}
}
