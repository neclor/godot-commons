class_name ScriptUtils extends Object


static func is_inherited_from(script: Script, parent_script: Script) -> bool:
	while script != null:
		if script == parent_script: return true
		script = script.get_base_script()
	return false
