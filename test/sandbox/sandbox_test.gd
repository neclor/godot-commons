@tool
extends EditorScript


func _run() -> void:
	
	#print(is_instance_of(obj, ClassDB))
	print(Singleton.new())
	
	print(Singleton.get_instance_of(Singleton))
	print(Sing.get_instance_of(Singleton))
	
	print(Sing.get_instance_of(Sing))
	print(Singleton.get_instance_of(Sing))
	
	
	
	print(Singleton.new())
	
	
	
	print("------------")
	print(ScriptUtils.is_inherited_from(AAA, AAA))
	
	var arut: Script = AAA
	

	print(is_instance_of(arut, Script))
	print(arut.is_class("Script"))
	print(arut.get_base_script())

	return 
	
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
