@tool
extends EditorScript


func _run() -> void:
	var item_scene: PackedScene = load("res://game/items/item.tscn")
	var item1: Item = item_scene.instantiate()
	var item2: Item = item_scene.instantiate()
	var item3: Item = item_scene.instantiate()
	var item4: Item = item_scene.instantiate()
	item1.weight = 1
	item2.weight = 1
	item3.weight = 0
	item4.weight = 0

	var item_container: ItemContainer = ItemContainer.new()
	assert(item_container.try_set_weight_limit_enabled(true))
	assert(item_container.try_set_items_limit_enabled(true))
	assert(item_container.try_set_weight_limit(1))
	assert(item_container.try_set_items_limit(2))

	assert(item_container.try_add_item(item1))
	assert(not item_container.try_add_item(item1))

	assert(not item_container.try_add_item(item2))
	assert(item_container.try_add_item(item3))

	assert(not item_container.try_add_item(item4))

	assert(item_container.try_erase_item(item1))
	assert(not item_container.try_erase_item(item1))

	prints(get_script().resource_path, "COMPLETED")
