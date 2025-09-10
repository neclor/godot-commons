using Neclor.Commons.Lib;


namespace Neclor.Commons.Extensions;


public static class IntExtensions {

#pragma warning disable CA1034
	extension(int i) {

		public static int Wrap(int value, int min, int max) {
			return MathLib.Wrap(value, min, max);
		}
	}
#pragma warning restore CA1034
}
