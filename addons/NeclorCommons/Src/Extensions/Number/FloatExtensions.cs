using Neclor.Commons.Lib;


namespace Neclor.Commons.Extensions;


[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible")]
public static class FloatExtensions {

	const float ThirdTau = float.Tau / 3;
	const float HalfPi = float.Pi / 2;
	const float ThirdPi = float.Pi / 3;

	const float MinAngle = -float.Pi;
	const float MaxAngle = float.Pi;

	extension(float f) {

		public static float ThirdTau => ThirdTau;

		public static float HalfPi => HalfPi;

		public static float ThirdPi => ThirdPi;

		public static float MinAngle => MinAngle;

		public static float MaxAngle => MaxAngle;

		public static bool IsZeroApprox(float value) {
			return MathLib.IsZeroApprox(value);
		}
				
		public static float Wrap(float value, float min, float max) {
			return MathLib.Wrap(value, min, max);
		}

		public static float WrapAngle(float angle) {
			return MathLib.WrapAngle(angle);
		}	

		public static float WrapAngleDegrees(float angle) {
			return MathLib.WrapAngleDegrees(angle);
		}

		public static float DecayWeight(float decay, float delta) {
			return MathLib.DecayWeight(decay, delta);
		}

		public static float DecayWeight(float decay, double delta) {
			return MathLib.DecayWeight(decay, delta);
		}
	}
}
