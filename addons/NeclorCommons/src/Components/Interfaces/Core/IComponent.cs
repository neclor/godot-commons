namespace Neclor.Commons.Components.Interfaces.Core;


public interface IComponent {

	IComponentManager ComponentManager { get; set; }

	void ComponentAdded(IComponentManager сomponentManager) { }

	void ComponentRemoved(IComponentManager сomponentManager) { }
}
