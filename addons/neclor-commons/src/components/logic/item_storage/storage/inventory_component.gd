class_name Inventor extends ItemContainer


var parent: Node = null


func _enter_tree() -> void:
	parent = get_parent()
	_items.all(func(item: Item): item.try_add_effect(parent))


func _exit_tree() -> void:
	_items.all(func(item: Item): item.try_remove_effect())
	parent = null


#region Items Management
func try_add_item(new_item: Item) -> bool:
	if not super(new_item): return false
	if parent == null: return true
	new_item.try_add_effect(parent)
	return true


func try_remove_item(item: Item) -> bool:
	if not item.try_suspend_effect(): return false
	if not super(item): return false
	pass

func update_item_effects() -> void:
	pass
#endregion
