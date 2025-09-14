using Neclor.Common.Utils;


namespace Neclor.Common.Extensions;


public static class FloatExtensions {

	const float ThirdTau = float.Tau / 3;
	const float HalfPi = float.Pi / 2;
	const float ThirdPi = float.Pi / 3;

	const float MinAngle = -float.Pi;
	const float MaxAngle = float.Pi;

#pragma warning disable CA1034
	extension(float f) {

		public static float ThirdTau => ThirdTau;

		public static float HalfPi => HalfPi;

		public static float ThirdPi => ThirdPi;

		public static float MinAngle => MinAngle;

		public static float MaxAngle => MaxAngle;

		public static bool IsZeroApprox(float value) {
			return MathUtils.IsZeroApprox(value);
		}
				
		public static float Wrap(float value, float min, float max) {
			return MathUtils.Wrap(value, min, max);
		}

		public static float WrapAngle(float angle) {
			return MathUtils.WrapAngle(angle);
		}	

		public static float DecayWeight(float decay, float delta) {
			return MathUtils.DecayWeight(decay, delta);
		}
	}
#pragma warning restore CA1034
}
