using Neclor.Commons.Components.Interfaces;


namespace Neclor.Commons.Interfaces.Logic;


public class Activatable : IActivatable {

	private readonly Action? _activated;
	private readonly Action? _deactivated;

	public Activatable(Action? activated = null, Action? deactivated = null) {
		Activated = onActivate;
		Deactivated = onDeactivate;
	}

	public bool IsActive {
		get;
		set {
			if (field == value) return;
			field = value;

			IsActiveChanged(field);
			if (field) Activated();
			else Deactivated();



		}
	} = true;

	public void SetIsActive(bool value) {
		IsActive = value;
	}

	public void Activate() {
		IsActive = true;
	}

	public void Deactivate() {
		IsActive = false;
	}






}
