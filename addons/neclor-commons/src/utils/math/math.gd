class_name Math extends Object


## Math utility library for common operations.


## Third of [constant @GDScript.TAU], equals 120 degrees
const THIRD_TAU: float = TAU / 3
## Half of [constant @GDScript.PI], equals 90 degrees
const HALF_PI: float = PI / 2
## One third of [constant @GDScript.PI], equals 60 degrees
const THIRD_PI: float = PI / 3


#region Public
#region Exp Decay
## Smoothly interpolates a [param from] toward a [param to] using exponential decay.
static func exp_decay(from: float, to: float, decay: float, delta: float) -> float:
	return lerp(from, to, _calculate_lerp_weight(decay, delta))


## Smoothly interpolates a [param from] toward a [param to] using exponential decay.
static func exp_decay_vector2(from: Vector2, to: Vector2, decay: float, delta: float) -> Vector2:
	return from.lerp(to, _calculate_lerp_weight(decay, delta))


## Smoothly interpolates a [param from] toward a [param to] using exponential decay.
static func exp_decay_vector3(from: Vector3, to: Vector3, decay: float, delta: float) -> Vector3:
	return from.lerp(to, _calculate_lerp_weight(decay, delta))


## Smoothly interpolates a [param from] toward a [param to] using exponential decay.
static func exp_decay_vector4(from: Vector4, to: Vector4, decay: float, delta: float) -> Vector4:
	return from.lerp(to, _calculate_lerp_weight(decay, delta))
#endregion


#region Array
## Returns true if all elements in two float arrays are approximately equal.
static func is_equal_approx_array(a: Array[float], b: Array[float]) -> bool:
	if a.size() != b.size(): return false
	for i in a.size(): if not is_equal_approx(a[i], b[i]): return false
	return true


## Multiplies each element in the array by a given [param x] and returns a new array.
static func mul_array(array: Array, x: float) -> Array:
	return array.map(func(i): return i * x)
#endregion


#region Vector
## Constructs a new [b]Vector2[/b] from [param Vector4].
static func vector2_from_vector4(from: Vector4) -> Vector2:
	return Vector2(from.x, from.y)


## Constructs a new [b]Vector3[/b] from [param Vector4].
static func vector3_from_vector4(from: Vector4) -> Vector3:
	return Vector3(from.x, from.y, from.z)


## Constructs a new [b]Vector4[/b] from [param Vector2].
static func vector4_from_vector2(from: Vector2) -> Vector4:
	return Vector4(from.x, from.y, 0, 0)


## Constructs a new [b]Vector4[/b] from [param Vector3].
static func vector4_from_vector3(from: Vector3) -> Vector4:
	return Vector4(from.x, from.y, from.z, 0)
#endregion
#endregion


#region Private
static func _calculate_lerp_weight(decay: float, delta: float) -> float:
	return 1 - exp(-decay * delta)
#endregion
