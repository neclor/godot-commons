using System.Diagnostics.CodeAnalysis;
using Neclor.Commons.Extensions;


namespace Neclor.Commons.Components.Interfaces.Core;


public interface IComponentManager {

	protected Dictionary<Type, List<IComponent>> ComponentsMap { get; }

	void Add(IComponent component) {
		ArgumentNullException.ThrowIfNull(component);

		if (Contains(component)) throw new ArgumentException("The component is already added.", nameof(component));

		AddToComponentsMap(component);
	}

	bool TryAdd(IComponent component) {
		ArgumentNullException.ThrowIfNull(component);

		if (Contains(component)) return false;

		AddToComponentsMap(component);

		return true;
	}

	bool Contains(IComponent component) {
		ArgumentNullException.ThrowIfNull(component);

		return ComponentsMap.TryGetValue(component.GetType(), out List<IComponent>? componentList) && componentList.Contains(component);
	}

	bool ContainsType<T>() {
		return ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Count > 0;
	}

	bool Remove(IComponent component) {
		ArgumentNullException.ThrowIfNull(component);

		if (!Contains(component)) return false;

		foreach (Type type in TypeCache.GetAllTypes(component.GetType())) {
			ComponentsMap[type].Remove(component);
		}

		component.ComponentRemoved(this);
		ComponentRemoved(component);

		return true;
	}

	bool TryGetComponent<T>([MaybeNullWhen(false)] out T component) {
		if (ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Count > 0) {
			component = (T)componentList[0];
			return true;
		}

		component = default;
		return false;
	}

	T[] TryGetComponents<T>() {
		if (ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList)) return [.. componentList.Cast<T>()];

		return [];
	}

	void ComponentAdded(IComponent сomponentManager) { }

	void ComponentRemoved(IComponent сomponentManager) { }

	private void AddToComponentsMap(IComponent component) {

		foreach (Type type in TypeCache.GetAllTypes(component.GetType())) {
			if (!ComponentsMap.TryGetValue(type, out List<IComponent>? componentList)) ComponentsMap[type] = componentList = [];
			componentList.Add(component);
		}

		component.ComponentAdded(this);
		ComponentAdded(component);
	}
}
