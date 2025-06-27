class_name AngleUtils extends Object


## Utility functions for angles.


## Third of [constant @GDScript.TAU], equals 120 degrees.
const THIRD_TAU: float = TAU / 3
## Half of [constant @GDScript.PI], equals 90 degrees.
const HALF_PI: float = PI / 2
## Third of [constant @GDScript.PI], equals 60 degrees.
const THIRD_PI: float = PI / 3


## Equals -[constant @GDScript.PI]
const MIN: float = -PI
## Equals [constant @GDScript.PI]
const MAX: float = PI


## Wraps the [param angle] between [constant MIN] and [constant MAX].
static func wrap_angle(angle: float) -> float:
	return wrapf(angle, MIN, MAX)


## Wraps the [param angle_degrees] between [code]-180[/code] and [code]180[/code].
static func wrap_angle_degrees(angle_degrees: float) -> float:
	return rad_to_deg(wrap_angle(deg_to_rad(angle_degrees)))
