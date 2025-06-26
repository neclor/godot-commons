class_name TopDownCharacter2DMoveComponent extends Character2DMoveComponent



@export var rotation: float = 0.0:
	get = get_rotation,
	set = set_rotation



func _physics_process(delta: float) -> void:
	if not active or character == null: return
	var half_delta_velocity: Vector2 = _force / mass * delta / 2
	character.velocity += half_delta_velocity
	character.velocity = character.velocity.lerp(speed * input_direction, Math.decay_weight(decay, delta))
	var pre_collision_velocity: Vector2 = character.velocity
	character.move_and_slide()
	character.velocity += half_delta_velocity
	_reset_force()

	_push_rigid_bodies(pre_collision_velocity)


#region Setters And Getters
func get_rotation() -> float:
	return rotation


func set_rotation(new_rotation: float) -> void:
	rotation = AngleUtils.wrap_angle(new_rotation)
#endregion


func _push_rigid_bodies(pre_collision_velocity: Vector2):
	var push_logic: Callable
	match rigid_body_push_mode:
		RigidBodyPushMode.FORCE: 
			push_logic = func(collider: RigidBody2D, collision_velocity: Vector2) -> void:
				collider.apply_central_force(collision_velocity * force_scale * collider.mass if ignore_collider_mass else 1)

		RigidBodyPushMode.INSTANT: 
			push_logic = func(collider: RigidBody2D, collision_velocity: Vector2) -> void:
				collider.set_axis_velocity(collision_velocity)

		RigidBodyPushMode.DISABLED: return
		_: return 

	for i in character.get_slide_collision_count():
		var collision: KinematicCollision2D = character.get_slide_collision(i)
		var collider: Object = collision.get_collider()
		if collider is not RigidBody2D: continue

		var collision_velocity: Vector2 = pre_collision_velocity.project(-collision.get_normal())
		push_logic.call(collider, collision_velocity)
