class_name Vector2iUtils extends Object


## Utility functions for [Vector2i].


## Constructs a new [b]Vector2i[/b] from [Vector3i].
static func from_vector3i(from: Vector3i) -> Vector2i:
	return Vector2i(from.x, from.y)


## Constructs a new [b]Vector2i[/b] from [Vector4i].
static func from_vector4i(from: Vector4i) -> Vector2i:
	return Vector2i(from.x, from.y)
