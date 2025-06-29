class_name MouseHoverSystem extends Node


var current_hovered := null


func _process(_delta):
	var mouse_pos = get_viewport().get_mouse_position()
	var space = get_world_2d().direct_space_state

	var result = space.intersect_point(mouse_pos, 32, [], collision_mask=1)

	if result.size() > 0:
		var new_hovered = result[0].collider
		if new_hovered != current_hovered:
			_on_hover_changed(current_hovered, new_hovered)
			current_hovered = new_hovered
	else:
		if current_hovered != null:
			_on_hover_changed(current_hovered, null)
			current_hovered = null

func _on_hover_changed(from, to):
	if from and from.has_method("on_hover_exit"):
		from.on_hover_exit()
	if to and to.has_method("on_hover_enter"):
		to.on_hover_enter()

☑ Пример объекта, который можно "ховерить":

# Например, Enemy.gd
extends Area2D

func on_hover_enter():
	modulate = Color(1, 1, 1, 1) # Подсветить

func on_hover_exit():
	modulate = Color(0.7, 0.7, 0.7, 1) # Убрать подсветку
