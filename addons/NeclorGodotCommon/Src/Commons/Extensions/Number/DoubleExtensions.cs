using Neclor.Commons.Lib;


namespace Neclor.Commons.Extensions;


public static class DoubleExtensions {

	const double ThirdTau = double.Tau / 3;
	const double HalfPi = double.Pi / 2;
	const double ThirdPi = double.Pi / 3;

	const double MinAngle = -double.Pi;
	const double MaxAngle = double.Pi;

#pragma warning disable CA1034
	extension(double d) {

		public static double ThirdTau => ThirdTau;

		public static double HalfPi => HalfPi;

		public static double ThirdPi => ThirdPi;

		public static double MinAngle => MinAngle;

		public static double MaxAngle => MaxAngle;

		public static bool IsZeroApprox(double value) {
			return MathLib.IsZeroApprox(value);
		}

		public static double Wrap(double value, double min, double max) {
			return MathLib.Wrap(value, min, max);
		}

		public static double WrapAngle(double angle) {
			return MathLib.WrapAngle(angle);
		}

		public static double DecayWeight(double decay, double delta) {
			return MathLib.DecayWeight(decay, delta);
		}
	}
#pragma warning restore CA1034
}
