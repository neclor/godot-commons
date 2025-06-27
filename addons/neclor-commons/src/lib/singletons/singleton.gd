class_name Singleton extends RefCounted


static var _instances: Dictionary[Script, Singleton] = {}
static var _internal_call: bool = false


static func instance_of(script: Script) -> Singleton:
	print("instance")
	if not _is_singleton(script): 
		var error_message: String = "[Singleton Error] Attempt to get instance from a non-singleton class."
		assert(false, error_message)
		push_error(error_message)
		return null

	if _instances.has(script): return _instances[script]

	_internal_call = true
	var new_instance: Singleton = script.new()
	_internal_call = false

	_instances[script] = new_instance
	return new_instance


static func _is_singleton(script: Script) -> bool:
	while script != null:
		print("is singl")
		if script == Singleton: return true
		script = script.get_base_script()
	return false


func _init() -> void:
	print("new")
	if _internal_call: return

	var error_message: String = "[Singleton Error] Attempt to create multiple instances of a Singleton. Use 'get_instance_of' instead of new()."
	assert(false, error_message)
	push_error(error_message)
