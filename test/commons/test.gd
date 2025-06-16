@tool
extends EditorScript


func _run() -> void:
	print("TEST")
	run_test_scripts("res://test/game/")
	print("TEST COMPLETED")


func run_test_scripts(path: String) -> void:
	var dir: DirAccess = DirAccess.open(path)
	if dir == null: return

	dir.list_dir_begin()
	var file_name: String = dir.get_next()

	while file_name != "":
		var full_path: String = path + "/" + file_name
		if dir.current_is_dir() and file_name != "." and file_name != "..":
			run_test_scripts(full_path)

		elif file_name.ends_with(".gd"):
			var script: EditorScript = load(full_path).new()
			script._run()

		file_name = dir.get_next()
