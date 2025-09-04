﻿#if GODOT
using Vector2 = Godot.Vector2;
using Vector3 = Godot.Vector3;
using Vector4 = Godot.Vector4;
#else
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;
using Vector4 = System.Numerics.Vector4;
#endif


namespace Neclor.Commons.Extensions;


[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1034:Nested types should not be visible")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
public static class Vector3Extensions {

#if GODOT
	private static readonly Vector3 _nan = new Vector3(float.NaN, float.NaN, float.NaN);
#endif

	extension(Vector3 v) {

#if GODOT
		public static Vector3 NaN => _nan;
#endif

		public Vector2 ToVector2() => new Vector2(v.X, v.Y);

		public Vector4 ToVector4(float w = 0f) => new Vector4(v.X, v.Y, v.Z, w);

		public static Vector3 From(Vector2 from, float z = 0f) => from.ToVector3(z);

		public static Vector3 From(Vector4 from) => from.ToVector3();
	}
}