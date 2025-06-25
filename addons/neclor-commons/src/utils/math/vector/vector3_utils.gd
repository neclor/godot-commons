class_name Vector3Utils extends Object


## Utility functions for [Vector3].


## Constructs a new [b]Vector3[/b] from [Vector2].
static func from_vector2(from: Vector2) -> Vector3:
	return Vector3(from.x, from.y, 0.0)


## Constructs a new [b]Vector3[/b] from [Vector4].
static func from_vector4(from: Vector4) -> Vector3:
	return Vector3(from.x, from.y, from.z)
