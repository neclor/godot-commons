extends Polygon2D


@export var cam: Camera2D = null

func _process(_delta: float) -> void:
	position = cam.position
