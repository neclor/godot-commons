class_name Grid extends RefCounted


enum Cell {
	EMPTY,
	FILLED,
}


var size: Vector2i = Vector2.ZERO:
	get = get_size,
	set = set_size
var _data: Array[Cell] = []


var count: int:
	get = get_count
var center: Vector2i:
	get = get_center
var cells: Array[Vector2i]:
	get = get_cells


func _init(new_size: Vector2i = size) -> void:
	size = new_size


func set_cell(coords: Vector2i, cell: Cell) -> void:
	if coords.x >= size.x or coords.y >= size.y: return
	_data[ArrayUtils.index_from_vector2i(coords, size.x)] = cell


func get_cell(coords: Vector2i) -> Cell:
	if coords.x >= size.x or coords.y >= size.y: return Cell.EMPTY
	return _data[ArrayUtils.index_from_vector2i(coords, size.x)]


func fill_rect(position: Vector2i, rect_size: Vector2i, cell: Cell) -> void:
	for x in rect_size.x:
		for y in rect_size.y:
			set_cell(Vector2i(x, y) + position, cell)


#region Setters And Getters
func get_size() -> Vector2i:
	return size


func set_size(new_size: Vector2i) -> void:
	size = new_size.maxi(0)
	_data.resize(count)


func get_count() -> int:
	return size.x * size.y


func get_center() -> Vector2i:
	return size / 2


func get_cells() -> Array[Vector2i]:
	var cells: Array[Vector2i] = []
	for x in size.x:
		for y in size.y:
			var coords: Vector2i = Vector2i(x, y)
			if get_cell(Vector2i(x, y)) != Cell.EMPTY:
				cells.append(coords)
	return cells
#endregion
