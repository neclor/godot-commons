class_name HealthComponent extends StatComponent


signal resurrected(value: int)


@export_group("")
@export var dead: bool = false:
	get = get_dead,
	set = set_dead


func _init(new_max_value: int = max_value, new_value: int = value, new_dead: bool = dead) -> void:
	super(new_max_value, new_value)
	dead = new_dead


func set_value(new_value: int):
	if dead: return
	super(new_value)


func get_dead() -> bool:
	return dead


func set_dead(new_dead: bool) -> void:
	if new_dead: kill()
	else: resurrect()


func decrease_value(amount: int) -> void:
	if dead: return
	super(amount)


func increase_value(amount: int) -> void:
	if dead: return
	super(amount)


func try_decrease_value(amount: int) -> bool:
	if dead: return false
	return super(amount)


func try_increase_value(amount: int) -> bool:
	if dead: return false
	return super(amount)


func kill() -> void:
	set_value(0)


func resurrect(new_value: int = max_value) -> void:
	if not dead: return
	dead = false
	set_value(new_value)
	resurrected.emit(value)


func _check_zero() -> bool:
	if value != 0: return false

	dead = true
	on_zero.emit()
	return true
