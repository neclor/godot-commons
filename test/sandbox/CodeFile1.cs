


class Program {
	static void Main() {


		A collider = new B();


		if (collider is not B rigidBody) return;
		
		Console.WriteLine("this RigidBody2D");
		bool yes = rigidBody is B;
		Console.WriteLine(yes);
		
	}
}


class A {
}

class B : A {
}
