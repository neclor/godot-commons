class_name Math extends Object


## Math utility functions.


## Small threshold value used for approximate float comparisons.
const EPSILON: float = 1e-5


## Calculates a frame-rate-independent interpolation weight using the exponential decay formula: [code]1 - exp(-decay * delta)[/code]. [br]
## At [param decay] = 3, [method lerp] will cover 95% in about 1 second.
static func decay_weight(decay: float, delta: float) -> float:
	return 1 - exp(-decay * delta)


## Returns true if [param a] and [param b] are approximately equal to each other.
static func is_equal_approx_epsilon(a: float, b: float, epsilon: float = EPSILON) -> bool:
	if a == b: return true
	return abs(a - b) <= epsilon
