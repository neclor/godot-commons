class_name RotationComponent extends Node2D


signal target_rotation_reached()


@export_group("")
@export_range(0, 100, 1, "or_greater", "hide_slider") var decay: float = 20:
	get = get_decay,
	set = set_decay


var global_target_rotation: float:
	get = get_global_target_rotation,
	set = set_global_target_rotation
var global_target_rotation_degrees: float:
	get = get_global_target_rotation_degrees,
	set = set_global_target_rotation_degrees
var target_rotation: float = Math.wrap_angle(rotation):
	get = get_target_rotation,
	set = set_target_rotation
var target_rotation_degrees: float:
	get = get_target_rotation_degrees,
	set = set_target_rotation_degrees



func _ready():
	target_rotation = PI / 2
	print(target_rotation)


func _physics_process(delta: float) -> void:
	if is_at_target_rotation(): return
	rotation = lerp_angle(rotation, target_rotation, Math.decay_weight(decay, delta))
	prints(target_rotation, rotation, Math.is_equal_approx_epsilon(target_rotation, rotation, 1e-1))


#region Setters And Getters
func get_decay() -> float:
	return decay


func set_decay(new_decay: float) -> void:
	decay = maxf(0, new_decay)


func get_global_target_rotation() -> float:
	var parent: Node = get_parent()
	if parent == null or parent is not Node2D: return target_rotation
	return Math.wrap_angle(parent.global_rotation + target_rotation)


func set_global_target_rotation(new_global_target_rotation: float) -> void:
	var parent: Node = get_parent()
	if parent == null or parent is not Node2D: target_rotation = new_global_target_rotation
	target_rotation = new_global_target_rotation - parent.global_rotation


func get_global_target_rotation_degrees() -> float:
	return rad_to_deg(get_global_target_rotation())


func set_global_target_rotation_degrees(new_global_target_rotation_degrees: float) -> void:
	set_global_target_rotation(deg_to_rad(new_global_target_rotation_degrees))


func get_target_rotation() -> float:
	return target_rotation


func set_target_rotation(new_target_rotation: float) -> void:
	target_rotation = Math.wrap_angle(new_target_rotation)


func get_target_rotation_degrees() -> float:
	return rad_to_deg(target_rotation)


func set_target_rotation_degrees(new_target_rotation_degrees: float) -> void:
	target_rotation = deg_to_rad(new_target_rotation_degrees)
#endregion


func is_at_target_rotation() -> bool:
	return is_equal_approx(target_rotation, rotation)





#func get_direction() -> Vector2:
	#return direction


#func set_direction(new_direction: Vector2) -> void:
	#direction = new_direction.normalized()
