

using Neclor.Commons.Extensions;
using Neclor.Commons.Utils;



class Program {
	static void Main() {


		A collider = new B();


		if (collider is not B rigidBody) return;

		Console.WriteLine("this RigidBody2D");
		bool yes = rigidBody is B;
		Console.WriteLine(yes);


		float a = 10f;
		double delta = 0.016;

		float b = float.DecayWeight(a, delta);



		Console.WriteLine(Memorizer.Call<int>(mul, 3, 4));
		Console.WriteLine(Memorizer.Call<int>(mul, 3, 4));
		Console.WriteLine(Memorizer.Call<int>(mul, 3, 4));
		Console.WriteLine(Memorizer.Call<int>(mul, 3, 4));
		Console.WriteLine(Memorizer.Call<int>(mul, 3, 4));


	}






	static int mul(int a, int b) {
		Console.WriteLine("Calcules");
		return a * b;
	}
}

class A {



}

class B : A {


}
