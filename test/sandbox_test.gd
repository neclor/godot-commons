@tool
extends EditorScript


func _run() -> void:
	pass
	for x in 20:
		print(randi_range(10, 3))
	
	var stat: StatComponent = HealthComponent.new()
	var class_val: Object = StatComponent

	if stat is StatComponent:
		print("status")
	else:
		print("nooo")
	
