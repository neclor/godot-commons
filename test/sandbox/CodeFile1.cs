


class Program {
	static void Main() {


		A collider = new B();


		if (collider is not B rigidBody) {
			Console.WriteLine("Not RigidBody2D");
		}
		else {
			Console.WriteLine("this RigidBody2D");
			bool yes = rigidBody is B;
			Console.WriteLine(yes);
		}
	}
}


class A {
}

class B : A {
}
