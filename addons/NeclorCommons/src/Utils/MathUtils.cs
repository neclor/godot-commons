using Godot;


namespace NeclorCommons.Utils;


public static class MathfUtils {


	public const float ThirdTau = MathF.Tau / 3;
	public const float HalfPi = MathF.PI / 2;
	public const float ThirdPi = MathF.PI / 3;


	public const float MinAngle = -MathF.PI;
	public const float MaxAngle = MathF.PI;


	public static float DecayWeight(float decay, float delta) {
		return 1 - MathF.Exp(-decay * delta);
	}

	public static float WrapAngle(float value) {
		return Mathf.Wrap(value, MinAngle, MaxAngle);
	}

	public static float WrapAngleDegrees(float value) {
		return Mathf.RadToDeg(WrapAngle(Mathf.DegToRad(value)));
	}
}
