namespace Neclor.Commons.Utils;


public static class FloatExtensions {

	extension(float value) {
		public static float ThirdTau {
			get => float.Tau / 3;
		}
		public static float HalfPi {
			get => float.Pi / 2;
		}
		public static float ThirdPi {
			get => float.Pi / 3;
		}
	}
}
