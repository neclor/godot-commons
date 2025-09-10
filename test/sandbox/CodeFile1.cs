

using Neclor.Commons.Extensions;
using Neclor.Commons.Utils;

using Godot;

class Program {


	static void Main() {


		C a = new C();


		foreach (Type t in typeof(Node2D).GetBaseTypes()) {



			Console.WriteLine(t.ToString());

		}

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

class C : B {


}
