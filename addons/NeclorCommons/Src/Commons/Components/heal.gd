class_name  extends RefCounted


var value: int = 0:
	set(new_value):
		value = maxi(0, new_value)


func _init(new_value: int = 0) -> void:
	value = new_value
