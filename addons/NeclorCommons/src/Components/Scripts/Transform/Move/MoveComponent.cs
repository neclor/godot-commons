using Godot;
using NeclorCommons.Components.Interfaces;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class MoveComponent : Node, IComponent, IActivatable {


	[ExportGroup("")]
	[Export]
	public bool IsActive { get; set; } = true;


	public Vector2 InputDirection {
		get;
		set => field = value.Normalized();
	} = Vector2.Zero;


	#region Setters
	public void SetInputDirection(Vector2 value) {
		InputDirection = value;
	}
	#endregion
}
