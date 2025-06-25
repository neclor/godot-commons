@tool
extends EditorScript


func _run() -> void:
	
	var a: AAA = AAA.new()
	var b: AAA = AAA.new()
	var c = [1, 2, 3]
	
	print(c[4])
	var rng = RandomNumberGenerator.new()
	print(rng.seed)
	for i in 10:
		var r  = RandomNumberGenerator.new()
		print(r.seed)
	print(rng.seed)
