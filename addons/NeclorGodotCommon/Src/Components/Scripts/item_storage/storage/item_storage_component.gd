class_name ItemStorageComponent extends Node


@export_group("Weight Limit")
@export var weight_limit_enabled: bool = true:
	get = get_weight_limit_enabled,
	set = set_weight_limit_enabled
@export_range(0, 100, 1, "or_greater") var max_weight: int = 32:
	get = get_max_weight,
	set = set_max_weight
var _weight: int = 0:
	get = 
var weight: int:
	get = get_weight,
	set = set_weight


@export_group("Items Limit")
@export var item_count_limit_enabled: bool = false:
	get = get_item_count_limit_enabled,
	set = set_item_count_limit_enabled
@export_range(0, 100, 1, "or_greater") var max_item_count: int = 100:
	get = get_max_item_count,
	set = set_max_item_count
var item_count: int = 0:
	get = get_item_count,
	set = set_item_count


var _items: Array[Node] = []:


func get_weight_limit_enabled() -> bool:
	return weight_limit_enabled


func set_weight_limit_enabled(new_value: int) -> void:
	


func get_max_weight() -> int:
	return max_weight


func set_max_weight(new_value: int) -> void:
	


func get_weight() -> int:
	return weight


func set_weight(_new_value: int) -> void:
	return


func get_item_count_limit_enabled() -> bool:
	return item_count_limit_enabled


func set_item_count_limit_enabled(new_value: int) -> void:
	


func get_max_item_count() -> int:
	return max_item_count


func set_max_item_count(new_value: int) -> void:


func get_item_count() -> int:
	return item_count


func set_item_count(_new_value: int) -> void:
	return


#region Items Management
func try_add_item(new_item: Item) -> bool:
	if _weight_limit_enabled:
		if _weight_limit < _current_weight + new_item.weight: return false
	if _items_limit_enabled:
		if _items_limit < _items_number + 1: return false
	if _items.has(new_item): return false

	_items.append(new_item)
	_current_weight += new_item.weight
	_items_number += 1
	return true


func try_remove_item(item: Item) -> bool:
	_items.erase(item)
	if _items_number == _items.size(): return false
	_items_number = _items.size()
	return true
#endregion


#region Weight Limit
func get_weight_limit_enabled() -> bool:
	return _weight_limit_enabled


func try_set_weight_limit_enabled(enabled: bool) -> bool:
	if not enabled:
		_weight_limit_enabled = false
		return true
	if _weight_limit < _current_weight: return false
	_weight_limit_enabled = true
	return true


func get_weight_limit() -> int:
	return _weight_limit


func try_set_weight_limit(new_weight_limit: int) -> bool:
	if _weight_limit_enabled:
		if new_weight_limit < _current_weight: return false
	_weight_limit = maxi(0, new_weight_limit)
	return true


func get_current_weight() -> int:
	return _current_weight
#endregion


#region Items Limit
func get_items_limit_enabled() -> bool:
	return _items_limit_enabled


func try_set_items_limit_enabled(enabled: bool) -> bool:
	if not enabled:
		_items_limit_enabled = false
		return true
	if _items_limit < _items_number: return false
	_items_limit_enabled = true
	return true


func get_items_limit() -> int:
	return _items_limit


func try_set_items_limit(new_items_limit: int) -> bool:
	if _items_limit_enabled:
		if new_items_limit < _items_number: return false
	_items_limit = maxi(0, new_items_limit)
	return true


func get_items_number() -> int:
	return _items_number
#endregion
