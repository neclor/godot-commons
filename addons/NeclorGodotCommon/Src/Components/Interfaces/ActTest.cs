using Neclor.Commons.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Godot;
using Neclor.Godot.Common.Components;

namespace Neclor.Commons.Interfaces;


public partial class ActTest : Node {


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


		IActivatable a = new Activatable();

		a.Activate();

	}





}
