class_name CameraComponent extends Camera2D


@export_group("Zoom")
@export var min_zoom: Vector2 = Vector2(1, 1):
	get = get_min_zoom,
	set = set_min_zoom
@export var max_zoom: Vector2 = Vector2(2, 2):
	get = get_max_zoom,
	set = set_max_zoom


@export_group("Mouse Drag", "_mouse_drag_")
@export_range(0, 1, 0.01) var _mouse_drag_left_margin: float = 0.5
@export_range(0, 1, 0.01) var _mouse_drag_top_margin: float = 0.5
@export_range(0, 1, 0.01) var _mouse_drag_right_margin: float = 0.5
@export_range(0, 1, 0.01) var _mouse_drag_bottom_margin: float = 0.5


func _init() -> void:
	zoom = zoom.clamp(min_zoom, max_zoom)


func _process(_delta: float) -> void:
	var half_real_viewport_size: Vector2 = get_viewport_rect().size / zoom / 2
	var mouse_position: Vector2 = get_local_mouse_position()

	var left_edge: float = -half_real_viewport_size.x * _mouse_drag_left_margin
	var rignt_edge: float = half_real_viewport_size.x * _mouse_drag_right_margin
	var top_edge: float = -half_real_viewport_size.y * _mouse_drag_top_margin
	var bottom_edge: float = half_real_viewport_size.y * _mouse_drag_bottom_margin

	var edge: Vector2 = Vector2(
		left_edge if mouse_position.x < left_edge else rignt_edge if mouse_position.x > rignt_edge else mouse_position.x,
		top_edge if mouse_position.y < top_edge else bottom_edge if mouse_position.y > bottom_edge else mouse_position.y
	)

	position = (mouse_position - edge).clamp(
		-half_real_viewport_size - Vector2(left_edge, top_edge),
		half_real_viewport_size - Vector2(rignt_edge, bottom_edge)
	)






func get_min_zoom() -> Vector2:
	return min_zoom


func set_min_zoom(new_min_zoom: Vector2) -> void:
	min_zoom = new_min_zoom.clamp(Vector2.ZERO, max_zoom)


func get_max_zoom() -> Vector2:
	return max_zoom


func set_max_zoom(new_max_zoom: Vector2) -> void:
	max_zoom = new_max_zoom.max(min_zoom)


func zoom_in() -> void:
	if zoom >= max_zoom: return
	zoom *= 1.1
	if zoom > max_zoom: zoom = max_zoom


func zoom_out() -> void:
	if zoom <= min_zoom: return
	zoom /= 1.1
	if zoom < min_zoom: zoom = min_zoom


func zoom_to_min() -> void:
	zoom = min_zoom


func zoom_to_max() -> void:
	zoom = max_zoom
