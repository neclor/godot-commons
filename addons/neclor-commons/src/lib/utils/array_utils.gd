class_name ArrayUtils extends Object


## Utility functions for [Array].


## Returns true if all elements in two float arrays are approximately equal.
static func is_equal_approx_array(a: Array[float], b: Array[float]) -> bool:
	if a.size() != b.size(): return false
	for i in a.size(): if not is_equal_approx(a[i], b[i]): return false
	return true


## Multiplies each element in the array by a given [param x] and returns a new array.
static func mul_array(array: Array, x: float) -> Array:
	return array.map(func(i): return i * x)


## Converts a coordinate [param vector] into a linear index based on the given [param width] of the grid.
static func index_from_vector2i(vector: Vector2i, width: int) -> int:
	return index_from_xy(vector.x, vector.y, width)


## Converts coordinates [param x], [param y] into a linear index based on the given [param width] of the grid.
static func index_from_xy(x: int, y: int, width: int) -> int:
	return y * width + x
