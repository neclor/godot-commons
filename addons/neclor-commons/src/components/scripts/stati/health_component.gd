class_name HealthComponent extends StatiComponent


signal resurrected(value: int)


var _dead: bool = false


#region Setters And Getters
func set_value(new_value: int):
	if is_dead(): return
	if new_value <= 0 or max_value <= 0: _dead = true
	super(new_value)
#endregion


func is_dead() -> bool:
	return _dead


func kill() -> void:
	set_value_to_zero()


func resurrect(new_value: int = max_value) -> void:
	if not is_dead(): return
	_dead = false
	value = new_value
	if not is_dead(): resurrected.emit(value)
