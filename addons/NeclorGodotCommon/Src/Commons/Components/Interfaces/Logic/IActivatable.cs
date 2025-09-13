namespace Neclor.Commons.Components.Interfaces;


public interface IActivatable {

	bool IsActive { get; set; }

	void SetIsActive(bool value);

	void Activate();

	void Deactivate();

	protected void IsActiveChanged(bool value);

	protected void Activated();

	protected void Deactivated();
}
