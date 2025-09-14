using Neclor.Common.Utils;


namespace Neclor.Common.Extensions;


public static class IntExtensions {

#pragma warning disable CA1034
	extension(int i) {

		public static int Wrap(int value, int min, int max) {
			return MathUtils.Wrap(value, min, max);
		}
	}
#pragma warning restore CA1034
}
