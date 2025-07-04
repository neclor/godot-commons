using Godot;
using NeclorCommons.Components.Interfaces;
using System;
using System.Text.RegularExpressions;
using static Godot.XRServer;


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
	public RotationMode Mode { get; set; } = RotationMode.Lerp;


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
		set => AngleUtils.wrap_angle(value);
	} = 0.0f;






	#region Setters
	public void SetRotationSpeed(float speed) {
		RotationSpeed = speed;
	}

	public void SetDecay(float decay) {
		Decay = decay;
	}
	#endregion








}


signal desired_rotation_reached


enum RotationMode {
	LERP,
	LINEAR,
	DISABLED,
}



var global_desired_rotation: float:
	get = get_global_desired_rotation,
	set = set_global_desired_rotation
var desired_rotation: float = AngleUtils.wrap_angle(rotation):
	get = get_desired_rotation,
	set = set_desired_rotation


var is_at_desired_rotation: bool:
	get = get_is_at_desired_rotation


func _physics_process(delta: float) -> void:
	if not active or is_at_desired_rotation: return
	match rotation_mode:
		RotationMode.LERP: _lerp_physics_process(delta)
		RotationMode.LINEAR: _linear_physics_process(delta)
		RotationMode.DISABLED: return
		_: return

	if is_at_desired_rotation: desired_rotation_reached.emit()


func desired_rotation_look_at(global_point: Vector2) -> void:
	global_desired_rotation = global_position.angle_to_point(global_point)


#region Setters And Getters
func get_rotation_mode() -> RotationMode:
	return rotation_mode


func set_rotation_mode(new_rotation_mode: RotationMode) -> void:
	rotation_mode = new_rotation_mode


func get_rotation_speed() -> float:
	return rotation_speed


func set_rotation_speed(new_rotation_speed: float) -> void:
	rotation_speed = maxf(0, new_rotation_speed)


func get_decay() -> float:
	return decay


func set_decay(new_decay: float) -> void:
	decay = maxf(0, new_decay)


func get_global_desired_rotation() -> float:
	var parent: Node = get_parent()
	if parent == null or parent is not Node2D: return desired_rotation
	return AngleUtils.wrap_angle(parent.global_rotation + desired_rotation)


func set_global_desired_rotation(new_global_desired_rotation: float) -> void:
	var parent: Node = get_parent()
	if parent == null or parent is not Node2D: 
		desired_rotation = new_global_desired_rotation
	else:
		desired_rotation = new_global_desired_rotation - parent.global_rotation


func get_desired_rotation() -> float:
	return desired_rotation


func set_desired_rotation(new_desired_rotation: float) -> void:
	desired_rotation = AngleUtils.wrap_angle(new_desired_rotation)


func get_is_at_desired_rotation() -> bool:
	return is_equal_approx(rotation, desired_rotation)
#endregion


func _lerp_physics_process(delta: float) -> void:
	rotation = AngleUtils.wrap_angle(lerp_angle(rotation, desired_rotation, Math.decay_weight(decay, delta)))


func _linear_physics_process(delta: float) -> void:
	rotation = AngleUtils.wrap_angle(rotate_toward(rotation, desired_rotation, rotation_speed* delta))
