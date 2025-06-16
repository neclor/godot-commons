class_name StatComponent extends Node


signal max_value_changed(max_value: int)
signal value_changed(value: int)
signal value_decreased(amount: int)
signal value_increased(amount: int)
signal on_zero()
signal on_full(value: int)


@export_group("")
@export_range(0, 100, 1, "or_greater") var max_value: int = 100:
	get = get_max_value,
	set = set_max_value
@export_range(0, 100, 1, "or_greater") var value: int = 100:
	get = get_value,
	set = set_value


func _init(new_max_value: int = max_value, new_value: int = new_max_value) -> void:
	max_value = new_max_value
	value = new_value


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

	if old_value == value: return

	value_changed.emit(value)
	if not _check_zero(): _check_full()


func set_value_to_max() -> void:
	value = max_value


func is_zero() -> bool:
	return value == 0


func is_full() -> bool:
	return value == max_value


func decrease_max_value(amount: int) -> void:
	if amount <= 0: return
	max_value -= amount


func increase_max_value(amount: int) -> void:
	if amount <= 0: return
	max_value += amount


func decrease_value(amount: int) -> void:
	if amount <= 0: return

	var old_value: int = value
	value -= amount
	var difference: int = old_value - value
	if difference > 0: value_decreased.emit(difference)


func increase_value(amount: int) -> void:
	if amount <= 0: return

	var old_value: int = value
	value += amount
	var difference: int = value - old_value
	if difference > 0: value_increased.emit(difference)


func try_decrease_value(amount: int) -> bool:
	if value < amount: return false
	decrease_value(amount)
	return true


func try_increase_value(amount: int) -> bool:
	if max_value - value < amount: return false
	increase_value(amount)
	return true


func _check_zero() -> bool:
	if value != 0: return false

	on_zero.emit()
	return true


func _check_full() -> bool:
	if value != max_value: return false

	on_full.emit(value)
	return true
