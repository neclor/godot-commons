namespace Neclor.Commons.Components.Interfaces;


public interface IActivatable {

	bool IsActive { get; set; }

	public void SetIsActive(bool value) {
		IsActive = value;
	}

	public void Activate() {
		IsActive = true;
	}

	public void Deactivate() {
		IsActive = false;
	}

	void IsActiveChanged(bool value) { }

	void Activated() { }

	void Deactivated() { }
}
