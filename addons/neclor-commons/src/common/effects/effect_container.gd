class_name EffectContainer
extends Node2D


@export_group("")


func get_effects_number() -> int:
	return get_child_count()


func try_add_effect(new_effect: Effect) -> bool:
	if weight_limit_enabled:
		if _weight_limit < _current_weight + new_item.weight: return false
	if items_limit_enabled:
		if _items_limit <= _items_number: return false
	if _items.has(new_item): return false

	_items.append(new_item)
	_current_weight += new_item.weight
	_items_number += 1
	return true


func try_erase_item(item: Item) -> bool:
	_items.erase(item)
	if _items_number == _items.size(): return false
	_items_number -= 1
	return true
