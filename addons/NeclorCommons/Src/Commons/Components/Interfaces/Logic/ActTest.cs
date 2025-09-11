using Neclor.Commons.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neclor.Commons.Interfaces;


public class ActTest : IActivatable {


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




	void foo() {


		

	}

}
