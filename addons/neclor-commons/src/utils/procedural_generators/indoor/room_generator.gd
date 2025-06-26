class_name RoomGenerator extends ProceduralGenerator


const MIN_RECT_OVERLAP: Vector2i = Vector2i(2, 2)


var cell_size: Vector2i = Vector2i(2, 2):
	get = get_cell_size,
	set = set_cell_size
var room_size: Vector2i = Vector2i(14, 14):
	get = get_room_size,
	set = set_room_size


var min_rect_size: Vector2i = Vector2i(4, 4):
	get = get_min_rect_size,
	set = set_min_rect_size
var max_rect_size: Vector2i = Vector2i(8, 8):
	get = get_max_rect_size,
	set = set_max_rect_size


var extra_rect_count: int = 4:
	get = get_extra_rect_count,
	set = set_extra_rect_count


func _init(new_room_size: Vector2i = room_size) -> void:
	room_size = new_room_size


func generate(size: Vector2i = room_size) -> Grid:
	var grid: Grid = Grid.new(size * cell_size)

	var central_rect_size: Vector2i = rand_vector2i_range(min_rect_size, max_rect_size)
	var central_rect_position: Vector2i = room_size / 2 - central_rect_size / 2

	grid.fill_rect(central_rect_position * cell_size, central_rect_size * cell_size, grid.Cell.FILLED)

	for i in extra_rect_count: 
		var rect_size: Vector2i = rand_vector2i_range(min_rect_size, min_rect_size)

		var offset_amplitude: Vector2i = ((rect_size + central_rect_size) / 2 - MIN_RECT_OVERLAP).maxi(0)
		var rect_offset: Vector2i = rand_vector2i_range(-offset_amplitude, offset_amplitude)

		var rect_position: Vector2i = room_size / 2 - rect_size / 2 + rect_offset

		grid.fill_rect(rect_position * cell_size, rect_size * cell_size, grid.Cell.FILLED)

	return grid


#region Setters And Getters
func get_cell_size() -> Vector2i:
	return cell_size


func set_cell_size(new_cell_size: Vector2i) -> void:
	cell_size = new_cell_size.maxi(1)


func get_room_size() -> Vector2i:
	return room_size


func set_room_size(new_room_size: Vector2i) -> void:
	room_size = new_room_size.maxi(0)


func get_min_rect_size() -> Vector2i:
	return min_rect_size


func set_min_rect_size(new_min_rect_size: Vector2i) -> void:
	min_rect_size = new_min_rect_size.clamp(Vector2.ZERO, max_rect_size)


func get_max_rect_size() -> Vector2i:
	return max_rect_size


func set_max_rect_size(new_max_rect_size: Vector2i) -> void:
	max_rect_size = new_max_rect_size.max(min_rect_size)


func get_extra_rect_count() -> int:
	return extra_rect_count


func set_extra_rect_count(new_extra_rect_count: int) -> void:
	extra_rect_count = max(0, new_extra_rect_count)
#endregion
