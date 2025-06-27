class_name Vector4Utils extends Object


## Utility functions for [Vector4].


## Constructs a new [b]Vector4[/b] from [Vector2].
static func from_vector2(from: Vector2) -> Vector4:
	return Vector4(from.x, from.y, 0.0, 0.0)


## Constructs a new [b]Vector4[/b] from [Vector3].
static func from_vector3(from: Vector3) -> Vector4:
	return Vector4(from.x, from.y, from.z, 0.0)
