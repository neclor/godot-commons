namespace Neclor.Godot.Common.Components;


public interface IActivatable {

	bool IsActive { get; set; }

	void SetIsActive(bool value);

	void Activate() {

		Console.WriteLine("ssss");

	}

	void Deactivate();

	protected void OnActivated();
}
