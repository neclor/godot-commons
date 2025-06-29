class_name Character2DMoveComponent extends MoveComponent


enum RigidBodyPushMode {
	FORCE,
	INSTANT,
	DISABLED,
}


@export_group("")
@export var character: CharacterBody2D = null:
	get = get_character,
	set = set_character


@export_group("Speed")
@export_range(0, 100, 1, "or_greater", "hide_slider") var speed: float = 128:
	get = get_speed,
	set = set_speed
@export_range(0, 100, 1, "or_greater", "hide_slider") var decay: float = 20:
	get = get_decay,
	set = set_decay


@export_group("Physics")
@export_range(0.001, 100, 0.001, "or_greater", "exp") var mass: float = 1.0:
	get = get_mass,
	set = set_mass
@export var rigid_body_push_mode: RigidBodyPushMode = RigidBodyPushMode.FORCE:
	get = get_rigid_body_push_mode,
	set = set_rigid_body_push_mode
@export var ignore_collider_mass: bool = false:
	get = get_ignore_collider_mass,
	set = set_ignore_collider_mass
@export_range(0, 100, 0.001, "or_greater", "or_less") var force_scale: float = 1.0:
	get = get_force_scale,
	set = set_force_scale


var _force: Vector2 = Vector2.ZERO


func apply_central_force(force: Vector2) -> void:
	_force += force


func apply_central_impulse(impulse: Vector2) -> void:
	if character == null: return
	character.velocity += impulse / mass;


#region Setters And Getters
func get_character() -> CharacterBody2D:
	return character


func set_character(new_character: CharacterBody2D) -> void:
	character = new_character


func get_speed() -> float:
	return speed


func set_speed(new_speed: float) -> void:
	speed = maxf(0, new_speed)


func get_decay() -> float:
	return decay


func set_decay(new_decay: float) -> void:
	decay = maxf(0, new_decay)


func get_mass() -> float:
	return mass


func set_mass(new_mass: float) -> void:
	mass = maxf(0.001, new_mass)


func get_rigid_body_push_mode() -> RigidBodyPushMode:
	return rigid_body_push_mode


func set_rigid_body_push_mode(new_rigid_body_push_mode: RigidBodyPushMode) -> void:
	rigid_body_push_mode = new_rigid_body_push_mode


func get_ignore_collider_mass() -> bool:
	return ignore_collider_mass


func set_ignore_collider_mass(new_ignore_collider_mass: bool) -> void:
	ignore_collider_mass = new_ignore_collider_mass


func get_force_scale() -> float:
	return force_scale


func set_force_scale(new_force_scale: float) -> void:
	force_scale = new_force_scale
#endregion


func _reset_force() -> void:
	_force = Vector2.ZERO
