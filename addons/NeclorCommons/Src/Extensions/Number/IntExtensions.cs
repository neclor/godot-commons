using Neclor.Commons.Lib;


namespace Neclor.Commons.Extensions;


[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible")]
public static class IntExtensions {

	extension(int i) {

		public static int Wrap(int value, int min, int max) {
			return MathLib.Wrap(value, min, max);
		}
	}
}
