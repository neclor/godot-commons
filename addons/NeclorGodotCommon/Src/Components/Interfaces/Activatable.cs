namespace Neclor.Godot.Common.Components;


public class Activatable : IActivatable {

	private readonly Action? _activated;
	private readonly Action? _deactivated;

	public Activatable(Action? activated = null, Action? deactivated = null) {
		_activated = activated;
		_deactivated = deactivated;
	}

	public bool IsActive {
		get;
		set {
			if (field == value) return;
			field = value;
		}
	} = true;

	public void SetIsActive(bool value) {
		IsActive = value;
	}



	public void Deactivate() {
		IsActive = false;
	}

	public void OnActivated() {
		Console.WriteLine("dddadd");

	}


}
