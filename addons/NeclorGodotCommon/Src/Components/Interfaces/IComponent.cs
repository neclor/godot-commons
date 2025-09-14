namespace Neclor.Godot.Common.Components.Interfaces;


public interface IComponent {

	IComponentManager ComponentManager { get; set; }

	void ComponentAdded(IComponentManager сomponentManager) { }

	void ComponentRemoved(IComponentManager сomponentManager) { }
}
