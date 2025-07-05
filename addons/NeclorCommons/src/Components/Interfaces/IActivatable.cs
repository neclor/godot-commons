namespace NeclorCommons.Components.Interfaces;


public interface IActivatable {


	bool IsActive { get; set; }


	void SetIsActive(bool value) {
		IsActive = value;
	}

	void Activate() {
		IsActive = true;
	}

	void Deactivate() {
		IsActive = false;
	}
}
