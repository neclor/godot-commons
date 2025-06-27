class_name Vector3iUtils extends Object


## Utility functions for [Vector3i].


## Constructs a new [b]Vector3i[/b] from [Vector2i].
static func from_vector2i(from: Vector2i) -> Vector3i:
	return Vector3i(from.x, from.y, 0)


## Constructs a new [b]Vector3i[/b] from [Vector4i].
static func from_vector4i(from: Vector4i) -> Vector3i:
	return Vector3i(from.x, from.y, from.z)
