class_name SingletonTemplate extends RefCounted


#region Singleton Template
#The setter is not called during initial assignment at declaration.
static var instance = new():
	get = get_instance,
	set = _set_instance


func _init() -> void:
	if instance == null: return
	var error_message: String = "[Singleton Error] Attempt to create multiple instances of a singleton. Use 'instance' instead of new()."
	assert(false, error_message)
	push_error(error_message)


#region Setters And Getters
static func get_instance():
	return instance


func _set_instance(new_instance) -> void:
	var error_message: String = "[Singleton Error] Attempt to assign a value to 'instance' manually."
	assert(false, error_message)
	push_error(error_message)
	return
#endregion
#endregion
