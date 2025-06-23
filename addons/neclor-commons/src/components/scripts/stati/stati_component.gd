class_name StatiComponent extends Node


signal max_value_changed(max_value: int)
signal on_full(value: int)
signal on_zero()
signal value_changed(value: int)
signal value_decreased(amount: int)
signal value_increased(amount: int)


@export_group("")
@export_range(0, 100, 1, "or_greater") var max_value: int = 100:
	get = get_max_value,
	set = set_max_value
@export_range(0, 100, 1, "or_greater") var value: int = 100:
	get = get_value,
	set = set_value


var is_full: bool:
	get = get_is_full
var is_zero: bool:
	get = get_is_zero


func _init(new_max_value: int = max_value, new_value: int = new_max_value) -> void:
	max_value = new_max_value
	value = new_value


func decrease_max_value(amount: int) -> int:
	var old_max_value: int = max_value
	max_value -= amount
	return old_max_value - max_value


func increase_max_value(amount: int) -> int:
	var old_max_value: int = max_value
	max_value += amount
	return max_value - old_max_value


func decrease_value(amount: int) -> int:
	var old_value: int = value
	value -= amount
	return old_value - value


func increase_value(amount: int) -> int:
	var old_value: int = value
	value += amount
	return value - old_value


func set_value_to_max() -> void:
	value = max_value


func set_value_to_zero() -> void:
	value = 0


#region Setters And Getters
func get_max_value() -> int:
	return max_value


func set_max_value(new_max_value: int) -> void:
	var old_max_value: int = max_value
	max_value = maxi(0, new_max_value)
	if old_max_value == max_value: return
	max_value_changed.emit(max_value)

	var old_value: int = value
	value = value
	if old_value == value and value == max_value: on_full.emit(value)


func get_value() -> int:
	return value


func set_value(new_value: int) -> void:
	var old_value: int = value
	value = clampi(new_value, 0, max_value)
	var difference: int = value - old_value
	if difference == 0: return

	value_changed.emit(value)
	if difference > 0: value_increased.emit(difference)
	else: value_decreased.emit(-difference)
	if is_full: on_full.emit(value)
	if is_zero: on_zero.emit()


func get_is_full() -> bool:
	return value == max_value


func get_is_zero() -> bool:
	return value == 0
#endregion
