class_name InputComponent extends Node


signal direction_changed(direction: Vector2)
signal scrolled_up
signal scrolled_down
signal accepted
signal selected
signal canceled
signal used
signal pressed_inventory
signal pressed_menu


enum Action {
	LEFT,
	RIGHT,
	UP,
	DOWN,
	ROTATE_CLOCKWISE,
	ROTATE_COUNTERCLOCKWISE,

	ABILITY,
	ABILITY_2,
	ABILITY_3,

	RUN,
	
	ATTACK,
	RELOAD,

	USE,
	INVENTORY,
	MENU,

	SCROLL_UP,
	SCROLL_DOWN,
	NEXT,
	PREV,
	ACCEPT,
	SELECT,
	CANCEL,
}


@export var enabled: bool = true#:
	#TODO
	#get = get_enabled,
	#set = set_enabled

@export var action_names: Dictionary[Action, String] = {
	Action.LEFT: "left",
	Action.RIGHT: "right",
	Action.UP: "up",
	Action.DOWN: "down",
	Action.SCROLL_UP: "scroll_up",
	Action.SCROLL_DOWN: "scroll_down",
	Action.ACCEPT: "accept",
	Action.SELECT: "select",
	Action.CANCEL: "cancel",
	Action.USE: "use",
	Action.INVENTORY: "inventory",
	Action.MENU: "menu",
}
#TODO


var input_direction: Vector2:
	get = get_input_direction
var _input_direction: Vector2 = Vector2.ZERO


func _unhandled_input(event: InputEvent) -> void:
	if _check_input_direction(): return
	elif event.is_action_pressed(_action_name(Action.SCROLL_UP)): scrolled_up.emit()
	#elif event.is_action_pressed(_action_name(Action.SCROLL_DOWN)): scrolled_down.emit()


#region Setters And Getters
func get_input_direction() -> Vector2:
	return _input_direction
#endregion


func _check_input_direction() -> bool:
	var new_input_direction: Vector2 = Vector2(
		Input.get_axis(_action_name(Action.LEFT), _action_name(Action.RIGHT)),
		Input.get_axis(_action_name(Action.UP), _action_name(Action.DOWN))
	)
	if _input_direction == new_input_direction: return false

	_input_direction = new_input_direction
	direction_changed.emit(_input_direction)
	return true


func _action_name(action: Action) -> String:
	return action_names.get(action, "")
