class_name RotationComponent extends Node2D


signal global_target_rotation_reached(global_rotation: float)
signal target_rotation_reached(rotation: float)



@export_group("")
@export_range(0, 100, 1, "or_greater", "hide_slider") var decay: float = 3:
	get = get_decay,
	set = set_decay

var global_target_rotation: float = global_rotation:
	get = get_global_target_rotation,
	set = get_global_target_rotation
var target_rotation: float = rotation:
	get = get_target_rotation,
	set = get_target_rotation



var is_rotation_target_reached: bool = true:
	get = get_is_rotation_target_reached,
	set = set_is_rotation_target_reached


func _physics_process(delta: float) -> void:
	
	rotation
	rotation = Math.wrap_angle(rotation + PI * delta)
	print(rotation)
	#rotation = Math.exp_decay_angle(rotation, rotation, lerp_decay, delta)
	pass
	#print(rotation)


func set_rotation(new_rotation: float) -> void:
	rotation = Math.wrap_angle(new_rotation)
	print("aaaa")


func get_decay() -> float:
	return decay


func set_decay(new_decay: float) -> void:
	decay = maxf(0, new_decay)



func get_target_rotation() -> float:
	return target_rotation


func set_target_rotation() -> float:
	return




func get_global_target_rotation() -> float:
	return target_rotation
	
func set_global_target_rotation() -> float:
	return




#func get_direction() -> Vector2:
	#return direction


#func set_direction(new_direction: Vector2) -> void:
	#direction = new_direction.normalized()
