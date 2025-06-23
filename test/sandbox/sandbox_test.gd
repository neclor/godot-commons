@tool
extends EditorScript


func _run() -> void:
	print(Math.normalized_isometric_vector2(Vector2(1, 1)))
	print(Math.is_equal_approx_epsilon(INF, INF))
	var hc: HealthComponent = HealthComponent.new()
	var type: Object = StatiComponent
	print(typeof(type))
	prints(hc, type, is_instance_of(hc, type))

	prints(PI, Math.wrap_angle(PI))
	print(Math.wrap_angle(PI), Math.wrap_angle(-PI))


	var p: float = 0.0
	var x: float = 100.0
	
	var time: float = 0.0
	print("--------------------------------------")
	for i in 20:
		prints(p, time)
		p = lerpf(p, x, Math.decay_weight(6, 0.1))
		time += 0.1
		OS.delay_msec(100)
