using Neclor.Commons.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Godot;

namespace Neclor.Commons.Interfaces;


public partial class ActTest : Node, IActivatable {


	public bool IsActive {
		get;
		set {
			if (field == value) return;
			field = value;

			//IsActiveChanged(field);
			//if (field) Activated();
			//else Deactivated();
		}
	}

	[Signal]
	public delegate void ActivatedSignalEventHandler(bool value);



	void Foo() {



		Activate();


	}






	void SetIsActive(bool value) {
		((IActivatable)this).SetIsActive(value);
	}



	void Deactivate() {
		((IActivatable)this).Deactivate();
	}

	void IsActiveChanged(bool value) {

		EmitSignal(SignalName.ActivatedSignal, value);
	}

	void Activated() { }

	void Deactivated() { }


}
