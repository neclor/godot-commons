class_name PointLight2DSceneComponent extends PointLight2D


#region new()
static func new() -> Camera2DSceneComponent:
	var packed_scene: PackedScene = preload(
		"res://addons/neclor-commons/src/components/scenes/point_light/point_light_2d_scene_component.tscn"
	)
	return packed_scene.instantiate()
#endregion
