using System.Numerics;


namespace Neclor.Commons.Lib;


public static class MathLib {

	public const float ThirdTauF = float.Tau / 3;
	public const float HalfPiF = float.Pi / 2;
	public const float ThirdPiF = float.Pi / 3;

	public const float MinAngleF = -float.Pi;
	public const float MaxAngleF = float.Pi;

	public const double ThirdTau = double.Tau / 3;
	public const double HalfPi = double.Pi / 2;
	public const double ThirdPi = double.Pi / 3;

	public const double MinAngle = -double.Pi;
	public const double MaxAngle = double.Pi;


	public static T RadiansToDegrees<T>(T radians) where T : IFloatingPoint<T> {
		return radians * T.CreateSaturating(180.0) / T.Pi;
	}

	public static T DegreesToRadians<T>(T degrees) where T : IFloatingPoint<T> {
		return degrees * T.Pi / T.CreateChecked(180.0);
	}


	public static bool IsZeroApprox(float value) {
		return float.Abs(value) < 1e-06f;
	}

	public static bool IsZeroApprox(double value) {
		return double.Abs(value) < 1e-14;
	}

	public static bool IsZeroApprox<T>(T value) where T : INumber<T> {
		if (T.IsInteger(value)) return value == T.Zero;
		return T.Abs(value) <= T.CreateSaturating(1e-6);
	}


	public static int Wrap(int value, int min, int max) {
		int num = max - min;

		if (num == 0) return min;

		return min + ((value - min) % num + num) % num;
	}

	public static float Wrap(float value, float min, float max) {
		float num = max - min;

		if (IsZeroApprox(num)) return min;

		return min + ((value - min) % num + num) % num;
	}

	public static double Wrap(double value, double min, double max) {
		double num = max - min;

		if (IsZeroApprox(num)) return min;

		return min + ((value - min) % num + num) % num;
	}

	public static T Wrap<T>(T value, T min, T max) where T : INumber<T> {
		T num = max - min;

		if (IsZeroApprox(num)) return min;

		return min + ((value - min) % num + num) % num;
	}


	public static float WrapAngle(float angle) {
		return Wrap(angle, MinAngleF, MaxAngleF);
	}

	public static double WrapAngle(double angle) {
		return Wrap(angle, MinAngle, MaxAngle);
	}

	public static T WrapAngle<T>(T angle) where T : IFloatingPoint<T> {
		return Wrap(angle, T.CreateSaturating(MinAngle), T.CreateSaturating(MaxAngle));
	}


	public static float WrapAngleDegrees(float angle) {
		return float.RadiansToDegrees(WrapAngle(float.DegreesToRadians(value)));
	}

	public static double WrapAngleDegrees(double angle) {
		return double.RadiansToDegrees(WrapAngle(double.DegreesToRadians(value)));
	}

	public static T WrapAngleDegrees<T>(T angle) where T : IFloatingPoint<T> {
		return RadiansToDegrees(WrapAngle(DegreesToRadians(angle)));
	}


	public static float DecayWeight(float decay, float delta) {
		return 1f - float.Exp(-decay * delta);
	}

	public static float DecayWeight(float decay, double delta) {
		return DecayWeight(decay, (float)delta);
	}

	public static double DecayWeight(double decay, double delta) {
		return 1.0 - double.Exp(-decay * delta);
	}

	public static T DecayWeight<T>(T decay, T delta) where T : IFloatingPointIeee754<T> {
		return T.One - T.Exp(-decay * delta);
	}
}
