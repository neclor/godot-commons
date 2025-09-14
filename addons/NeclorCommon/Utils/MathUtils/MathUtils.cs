using System.Numerics;


namespace Neclor.Common.Utils;


public static class MathUtils {

	public const double ThirdTau = double.Tau / 3;
	public const double HalfPi = double.Pi / 2;
	public const double ThirdPi = double.Pi / 3;

	public const double MinAngle = -double.Pi;
	public const double MaxAngle = double.Pi;

	public const double Epsilon = 1e-06;

	public static bool IsZeroApprox<T>(T value) where T : IFloatingPoint<T> {
		return T.Abs(value) < GenericConstants<T>.Epsilon;
	}

	public static int Wrap(int value, int min, int max) {
		int num = max - min;

		if (num == 0) return min;

		return min + ((value - min) % num + num) % num;
	}

	public static T Wrap<T>(T value, T min, T max) where T : IFloatingPoint<T> {
		T num = max - min;

		if (IsZeroApprox(num)) return min;

		return min + ((value - min) % num + num) % num;
	}

	public static T WrapAngle<T>(T angle) where T : IFloatingPoint<T> {
		return Wrap(angle, GenericConstants<T>.MinAngle, GenericConstants<T>.MaxAngle);
	}

	public static T DecayWeight<T>(T decay, T delta) where T : IFloatingPointIeee754<T> {
		return T.One - T.Exp(-decay * delta);
	}

	private static class GenericConstants<T> where T : IFloatingPoint<T> {

		public static readonly T MinAngle = T.CreateSaturating(MathUtils.MinAngle);
		public static readonly T MaxAngle = T.CreateSaturating(MathUtils.MaxAngle);

		public static readonly T Epsilon = T.CreateSaturating(MathUtils.Epsilon);
	}
}
