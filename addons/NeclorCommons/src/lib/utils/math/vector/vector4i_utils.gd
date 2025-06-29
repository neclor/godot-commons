class_name Vector4iUtils extends Object


## Utility functions for [Vector4i].


## Constructs a new [b]Vector4i[/b] from [Vector2i].
static func from_vector2i(from: Vector2i) -> Vector4i:
	return Vector4i(from.x, from.y, 0, 0)


## Constructs a new [b]Vector4i[/b] from [Vector3i].
static func from_vector3i(from: Vector3i) -> Vector4i:
	return Vector4i(from.x, from.y, from.z, 0)
