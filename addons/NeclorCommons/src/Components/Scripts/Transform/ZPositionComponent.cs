using Godot;
using Neclor.Commons.Components.Interfaces;


namespace Neclor.Commons.Components.Scripts;


public partial class ZPositionComponent : Node2D, IComponent {


	public float PositionZ {
		get;
		set {
			field = value;
			Position = Position with { Y = field };
		}
	} = 0.0f;


	public float VelocityZ { get; set; } = 0.0f;


	public bool IsOnFloor => PositionZ <= 0.0f;


	public override void _Ready() {
		PositionZ = Position.Y;
	}


	public override void _PhysicsProcess(double delta) {
		if (VelocityZ == 0.0f) return;
		PositionZ += VelocityZ * (float)delta;
		if (IsOnFloor) VelocityZ = 0.0f;
	}
}
