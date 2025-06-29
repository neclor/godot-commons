class_name IActivalableComponentNode extends IComponentNode


signal active_changed(active: bool)
signal activated
signal deactivated


@export var active: bool = true:
	get = get_active,
	set = set_active


func activate() -> void:
	active = true


func deactivate() -> void:
	active = false


#region Setters And Getters
func get_active() -> bool:
	return active


func set_active(new_active: bool) -> void:
	if active == new_active: return
	active = new_active

	active_changed.emit(active)
	if active: activated.emit()
	else: deactivated.emit()
#endregion
