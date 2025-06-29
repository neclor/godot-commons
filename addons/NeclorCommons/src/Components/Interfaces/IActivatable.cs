using Godot;
using System;


namespace NeclorCommons.Components.Interfaces;


public interface IActivatable {


	public bool Active { get; set; }


	public void SetActive(bool active) {
		Active = active;
	}

	public void Activate() {
		Active = true;
	}

	public void Deactivate() {
		Active = false;
	}
}
