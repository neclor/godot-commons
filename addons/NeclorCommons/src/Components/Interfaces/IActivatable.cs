namespace NeclorCommons.Components.Interfaces;


public interface IActivatable {


	public bool IsActive { get; set; }


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
