class_name FPSCounter extends Label


var wait_time: float = 1


var _timer: Timer = Timer.new()


func _ready() -> void:
	_timer.wait_time = wait_time
	_timer.ignore_time_scale = true
	_timer.timeout.connect(_on_timer_timeout)
	add_child(_timer)
	_timer.start


func _on_timer_timeout():
	text = "FPS: %d" % int(Performance.get_monitor(Performance.TIME_FPS))
