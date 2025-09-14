using Godot;


namespace Neclor.Godot.Common.Extensions;


public static class Vector4Extensions {

	private static readonly Vector4 _nan = new Vector4(float.NaN, float.NaN, float.NaN, float.NaN);

#pragma warning disable CA1034, CA1822
	extension(Vector4 v) {

		public static Vector4 NaN => _nan;

		public Vector2 ToVector2() => new Vector2(v.X, v.Y);

		public Vector3 ToVector3() => new Vector3(v.X, v.Y, v.Z);

		public static Vector4 From(Vector2 from, float z = 0f, float w = 0f) => from.ToVector4(z, w);

		public static Vector4 From(Vector3 from, float w = 0f) => from.ToVector4(w);
	}
#pragma warning restore CA1034, CA1822
}

