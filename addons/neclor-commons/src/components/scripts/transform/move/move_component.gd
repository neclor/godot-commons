class_name MoveComponent extends IActivalableComponentNode


var input_direction: Vector2 = Vector2.ZERO:
	get = get_input_direction,
	set = set_input_direction


#region Setters And Getters
func get_input_direction() -> Vector2:
	return input_direction


func set_input_direction(new_input_direction: Vector2) -> void:
	input_direction = new_input_direction.normalized()
#endregion
