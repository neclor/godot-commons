class_name ExtendedRandomNumberGenerator extends RandomNumberGenerator


## Extended random number generator with utility functions.


## Absolutely random number.
const RANDOM_NUMBER: int = 42


#region Vector2/Vector2i
## Returns a random [b]Vector2[/b] in the range [param from], [param to] (inclusive).
func rand_vector2_range(from: Vector2, to: Vector2) -> Vector2:
	return Vector2Utils.from_vector4(rand_vector4_range(Vector4Utils.from_vector2(from), Vector4Utils.from_vector2(to)))


## Returns a random [b]Vector2i[/b] in the range [param from], [param to] (inclusive).
func rand_vector2i_range(from: Vector2i, to: Vector2i) -> Vector2i:
	return Vector2iUtils.from_vector4i(rand_vector4i_range(Vector4iUtils.from_vector2i(from), Vector4iUtils.from_vector2i(to)))
#endregion


#region Vector3/Vector3i
## Returns a random [b]Vector3[/b] in the range [param from], [param to] (inclusive).
func rand_vector3_range(from: Vector3, to: Vector3) -> Vector3:
	return Vector3Utils.from_vector4(rand_vector4_range(Vector4Utils.from_vector3(from), Vector4Utils.from_vector3(to)))


## Returns a random [b]Vector3i[/b] in the range [param from], [param to] (inclusive).
func rand_vector3i_range(from: Vector3i, to: Vector3i) -> Vector3i:
	return Vector3iUtils.from_vector4i(rand_vector4i_range(Vector4iUtils.from_vector3i(from), Vector4iUtils.from_vector3i(to)))
#endregion


#region Vector4/Vector4i
## Returns a random [b]Vector4[/b] in the range [param from], [param to] (inclusive).
func rand_vector4_range(from: Vector4, to: Vector4) -> Vector4:
	return Vector4(self.randf_range(from.x, to.x), self.randf_range(from.y, to.y), self.randf_range(from.z, to.z), self.randf_range(from.w, to.w))


## Returns a random [b]Vector4i[/b] in the range [param from], [param to] (inclusive).
func rand_vector4i_range(from: Vector4i, to: Vector4i) -> Vector4i:
	return Vector4i(self.randi_range(from.x, to.x), self.randi_range(from.y, to.y), self.randi_range(from.z, to.z), self.randi_range(from.w, to.w))
#endregion
