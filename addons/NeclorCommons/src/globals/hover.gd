extends Node2D


signal hpnd


var hovered_entity = null

func _process(_delta):
	pass
	#var pos = get_global_mouse_position()
	#var space = get_world_2d().direct_space_state
	##var result = space.intersect_point(pos, 1, [], collision_mask = 1 << 2, collide_with_areas = true)
#
	#if result:
		#var entity = result.collider
		#if entity != hovered_entity:
			#_on_new_hover(entity)
	#else:
		#if hovered_entity != null:
			#_on_hover_leave()




static func foo() -> void:
	hpnd.emit()
	
