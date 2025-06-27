extends Node2D






func _ready():
	Singleton.instance_of(ChildSinglton).sgnl.connect(_on_sgnl)
	Singleton.instance_of(ChildSinglton).sgnl.emit()


func _on_sgnl():
	print("signl")
