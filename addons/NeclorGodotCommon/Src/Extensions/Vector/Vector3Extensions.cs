using Godot;


namespace Neclor.Godot.Common.Extensions;


public static class Vector3Extensions {

	private static readonly Vector3 _nan = new Vector3(float.NaN, float.NaN, float.NaN);

#pragma warning disable CA1034, CA1822
	extension(Vector3 v) {

		public static Vector3 NaN => _nan;

		public Vector2 ToVector2() => new Vector2(v.X, v.Y);

		public Vector4 ToVector4(float w = 0f) => new Vector4(v.X, v.Y, v.Z, w);

		public static Vector3 From(Vector2 from, float z = 0f) => from.ToVector3(z);

		public static Vector3 From(Vector4 from) => from.ToVector3();
	}
#pragma warning restore CA1034, CA1822
}
