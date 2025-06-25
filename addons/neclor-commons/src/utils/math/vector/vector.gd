class_name Vector extends RefCounted


## Utility functions for vector operations.


## Returns a normalized isometric vector adjusted by the given projection scale.
## [param projection] controls the skew of the isometric projection (e.g., [code]Vector2(1, 0.5)[/code] for 2:1).
## [codeblock lang=gdscript]
## Utils.Vector.normalized_isometric_vector2(Vector2(1, 1)) # Returns (0.447214, 0.447214) for default 2:1 isometry
## [/codeblock]
static func normalized_isometric_vector2(from: Vector2, projection: Vector2 = Vector2(1, 0.5)) -> Vector2:
	return (from / projection).normalized() * projection


#region Vector2
## Constructs a new [b]Vector2[/b] from [Vector3].
static func vector2_from_vector3(from: Vector3) -> Vector2:
	return Vector2(from.x, from.y)


## Constructs a new [b]Vector2[/b] from [Vector4].
static func vector2_from_vector4(from: Vector4) -> Vector2:
	return Vector2(from.x, from.y)
#endregion


## Constructs a new [b]Vector2i[/b] from [Vector3].
static func vector2i_from_vector3i(from: Vector3i) -> Vector2i:
	return Vector2i(from.x, from.y)


## Constructs a new [b]Vector2i[/b] from [Vector4].
static func vector2i_from_vector4i(from: Vector4i) -> Vector2i:
	return Vector2i(from.x, from.y)


## Constructs a new [b]Vector3[/b] from [param Vector4].
static func vector3_from_vector4(from: Vector4) -> Vector3:
	return Vector3(from.x, from.y, from.z)


## Constructs a new [b]Vector4[/b] from [param Vector2].
static func vector4_from_vector2(from: Vector2) -> Vector4:
	return Vector4(from.x, from.y, 0, 0)


## Constructs a new [b]Vector4[/b] from [param Vector3].
static func vector4_from_vector3(from: Vector3) -> Vector4:
	return Vector4(from.x, from.y, from.z, 0)


#TODO: Create universal vector vector
