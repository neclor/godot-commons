@tool
extends EditorScript


func _run() -> void:
	var item_scene: PackedScene = load("res://game/items/item.tscn")
	var item: Item = item_scene.instantiate()
	item.weight = 1

	assert(item.weight == 1)

	prints(get_script().resource_path, "COMPLETED")
