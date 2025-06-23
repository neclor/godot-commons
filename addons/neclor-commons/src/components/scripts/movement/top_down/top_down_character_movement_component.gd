class_name TopDownCharacterMovementComponent extends Node


enum RigidBodyPushMode {
	FORCE,
	INSTANT,
	DISABLED,
}


@export_group("")
@export var character_body: CharacterBody2D = null:
	get = get_character_body,
	set = set_character_body


@export_group("Speed")
@export_range(0, 100, 1, "or_greater", "hide_slider") var speed: float = 128:
	get = get_speed,
	set = set_speed
@export_range(0, 100, 1, "or_greater", "hide_slider") var decay: float = 20:
	get = get_decay,
	set = set_decay


@export_group("Rigid Body Push")
@export var rigid_body_push_mode: RigidBodyPushMode = RigidBodyPushMode.FORCE:
	get = get_rigid_body_push_mode,
	set = set_rigid_body_push_mode
@export var ignore_collider_mass: bool = false:
	get = get_ignore_collider_mass,
	set = set_ignore_collider_mass
@export var force_scale: float = 1.0:
	get = get_force_scale,
	set = set_force_scale


var direction: Vector2 = Vector2.ZERO:
	get = get_direction,
	set = set_direction


func _physics_process(delta: float) -> void:
	if character_body == null: return
	character_body.velocity = character_body.velocity.lerp(direction * speed, Math.decay_weight(decay, delta))
	var pre_collision_velocity: Vector2 = character_body.velocity
	character_body.move_and_slide()

	_push_rigid_bodies(pre_collision_velocity)


#region Setters And Getters
func get_character_body() -> CharacterBody2D:
	return character_body


func set_character_body(new_character_body: CharacterBody2D) -> void:
	character_body = new_character_body


func get_speed() -> float:
	return speed


func set_speed(new_speed: float) -> void:
	speed = maxf(0, new_speed)


func get_decay() -> float:
	return decay


func set_decay(new_decay: float) -> void:
	decay = maxf(0, new_decay)


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


func get_direction() -> Vector2:
	return direction


func set_direction(new_direction: Vector2) -> void:
	direction = new_direction.normalized()
#endregion


func _push_rigid_bodies(pre_collision_velocity: Vector2):
	var lambda: Callable
	match rigid_body_push_mode:
		RigidBodyPushMode.FORCE: lambda = func(collider: RigidBody2D, collision_velocity: Vector2) -> void:
			collider.apply_central_force(collision_velocity * force_scale * (collider.mass if ignore_collider_mass else 1))
		RigidBodyPushMode.INSTANT: lambda = func(collider: RigidBody2D, collision_velocity: Vector2) -> void:
			collider.set_axis_velocity(collision_velocity)
		RigidBodyPushMode.DISABLED: return
		_: return 

	for i in character_body.get_slide_collision_count():
		var collision: KinematicCollision2D = character_body.get_slide_collision(i)
		var collider: Object = collision.get_collider()
		if collider is not RigidBody2D: continue

		var collision_velocity: Vector2 = pre_collision_velocity.project(-collision.get_normal())
		lambda.call(collider, collision_velocity)
