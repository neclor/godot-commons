class_name LoadingScreenTemplate extends CanvasLayer


var _counter: int = 0


@onready var _loading_label: Label = %LoadingLabel


func _on_timer_timeout():
	var text: String = "Loading"
	for i in _counter:
		text += "."

	_loading_label.text = text
	_counter = (_counter + 1) % 4
