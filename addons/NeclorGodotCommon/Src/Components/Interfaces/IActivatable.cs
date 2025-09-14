namespace Neclor.Godot.Common.Components;


public interface IActivatable {

	bool IsActive { get; set; }

	void SetIsActive(bool value);

	void Activate();

	void Deactivate();

	protected void OnIsActiveChanged(bool value);

	protected void OnActivated();

	protected void OnDeactivated();
}
