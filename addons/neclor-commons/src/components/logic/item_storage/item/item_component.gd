class_name ItemComponent extends Node


@export_group("")
@export_range(0, 100, 1, "or_greater") var weight: int = 0:
	get = get_weight,
	set = set_weight


func get_weight() -> int:
	return weight


func set_weight(new_value: int) -> void:
	weight = maxi(0, new_value)
