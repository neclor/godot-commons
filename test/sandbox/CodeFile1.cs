


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

		float b = MathUtils.DecayWeight(a, delta);




	}
}


class A {
}

class B : A {
}
