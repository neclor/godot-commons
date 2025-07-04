extends Node2D






func _ready():
	Singleton.instance_of(ChildSinglton).sgnl.connect(_on_sgnl)
	Singleton.instance_of(ChildSinglton).sgnl.emit()


func _on_sgnl():
	print("signl")


func _on_health_component_child_entered_tree(node:  Node, source: Node, extra_arg_0:  bool) -> void:
	pass # Replace with function body.
