using Godot;


namespace Neclor.Commons.Utils;


public static class MathfUtils {


	public const float ThirdTau = float.Tau / 3;
	public const float HalfPi = float.Pi / 2;
	public const float ThirdPi = float.Pi / 3;


	public const float MinAngle = -float.Pi;
	public const float MaxAngle = float.Pi;


	public static float DecayWeight(float decay, float delta) {
		return 1 - float.Exp(-decay * delta);
	}

	public static float DecayWeight(float decay, double delta) {
		return 1 - float.Exp(-decay * (float)delta);
	}

	public static float WrapAngle(float value) {
		return Mathf.Wrap(value, MinAngle, MaxAngle);
	}

	public static float WrapAngleDegrees(float value) {
		return float.RadiansToDegrees(WrapAngle(float.DegreesToRadians(value)));
	}
}
