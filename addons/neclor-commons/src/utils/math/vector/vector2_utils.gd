class_name Vector2Utils extends Object


## Utility functions for [Vector2].


## Constructs a new [b]Vector2[/b] from [Vector3].
static func from_vector3(from: Vector3) -> Vector2:
	return Vector2(from.x, from.y)


## Constructs a new [b]Vector2[/b] from [Vector3].
static func from_vector4(from: Vector4) -> Vector2:
	return Vector2(from.x, from.y)


## Returns a normalized isometric vector adjusted by the given projection scale.
## [param projection] controls the skew of the isometric projection (e.g., [code]Vector2(1, 0.5)[/code] for 2:1).
## [codeblock lang=gdscript]
## Utils.Vector.normalized_isometric_vector2(Vector2(1, 1)) # Returns (0.447214, 0.447214) for default 2:1 isometry
## [/codeblock]
static func normalized_isometric_vector2(from: Vector2, projection: Vector2 = Vector2(1, 0.5)) -> Vector2:
	return (from / projection).normalized() * projection
