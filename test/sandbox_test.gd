@tool
extends EditorScript


func _run() -> void:
	print(Math.normalized_isometric_vector2(Vector2(1, 1)))
	print(Math.is_equal_approx_epsilon(INF, INF))
