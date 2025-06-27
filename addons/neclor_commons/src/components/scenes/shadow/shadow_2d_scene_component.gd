class_name Shadow2DSceneComponent extends Sprite2D


#region new()
static func new() -> Camera2DSceneComponent:
	var packed_scene: PackedScene = preload(
		"res://addons/neclor-commons/src/components/scenes/shadow/shadow_2d_scene_component.tscn"
	)
	return packed_scene.instantiate()
#endregion
