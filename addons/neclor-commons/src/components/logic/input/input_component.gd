class_name InputComponent extends Node


signal input_direction_changed(direction: Vector2)
signal scrolled_up
signal scrolled_down
signal accepted
signal selected
signal canceled
signal used
signal pressed_inventory
signal pressed_menu


enum Action {
	MOVE_LEFT,
	MOVE_RIGHT,
	MOVE_UP,
	MOVE_DOWN,
	SCROLL_UP,
	SCROLL_DOWN,
	ACCEPT,
	SELECT,
	CANCEL,
	USE,
	INVENTORY,
	MENU,
}


@export var action_name: Dictionary[Action, String] = {
	Action.MOVE_LEFT: "move_left",
	Action.MOVE_RIGHT: "move_right",
	Action.MOVE_UP: "move_up",
	Action.MOVE_DOWN: "move_down",
	Action.SCROLL_UP: "scroll_up",
	Action.SCROLL_DOWN: "scroll_down",
	Action.ACCEPT: "accept",
	Action.SELECT: "select",
	Action.CANCEL: "cancel",
	Action.USE: "use",
	Action.INVENTORY: "inventory",
	Action.MENU: "menu",
}


var input_direction: Vector2:
	get = get_input_direction
var _input_direction: Vector2 = Vector2.ZERO


func _unhandled_input(event: InputEvent) -> void:
	_check_input_direction()
	if event.is_action_pressed(action_name.get(Action.SCROLL_UP, "")): scrolled_up.emit()
	elif event.is_action_pressed(action_name.get(Action.SCROLL_DOWN, "")): scrolled_down.emit()


func get_input_direction() -> Vector2:
	return _input_direction


func _check_input_direction() -> void:
	var new_input_direction: Vector2 = Vector2(
		Input.get_axis(action_name.get(Action.MOVE_LEFT, ""), action_name.get(Action.MOVE_RIGHT, "")),
		Input.get_axis(action_name.get(Action.MOVE_UP, ""), action_name.get(Action.MOVE_DOWN, ""))
	)
	if new_input_direction == _input_direction: return

	_input_direction = new_input_direction
	input_direction_changed.emit(_input_direction)
