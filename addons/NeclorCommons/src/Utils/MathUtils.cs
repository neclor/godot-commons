namespace NeclorCommons.Utils;


public static class MathUtils {


	public static float DecayWeight(float decay, float delta) {
		return 1 - MathF.Exp(-decay * delta);
	}
}
