using Godot;
using Neclor.Commons.Extensions;
using Neclor.Commons.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;


namespace Neclor.Commons.Components.Interfaces.Core;


public interface IComponentManager {

	protected Dictionary<Type, List<IComponent>> ComponentsMap { get; }

	void Add<T>(T component) where T : IComponent {
		ArgumentNullException.ThrowIfNull(component);

		if (Contains(component)) throw new ArgumentException("The component is already added.", nameof(component));

		AddToComponentsMap(component);
	}

	bool TryAdd<T>(T component) where T : IComponent {
		ArgumentNullException.ThrowIfNull(component);

		if (Contains(component)) return false;

		AddToComponentsMap(component);

		return true;
	}

	bool Contains<T>(T component) where T : IComponent {
		ArgumentNullException.ThrowIfNull(component);

		return ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Contains(component);
	}

	bool ContainsType<T>() where T : IComponent {
		return ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Count > 0;
	}

	bool Remove<T>(T component) where T : IComponent {
		ArgumentNullException.ThrowIfNull(component);

		if (ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Remove(component)) {
			component.ComponentRemoved(this);
			ComponentRemoved(component);
			return true;
		}

		return false;
	}

	/* 
	 
	 		List<IComponent>? componentList;
		if (!ComponentsMap.TryGetValue(typeof(T), out componentList)) {
			component = default;
			return false;
		}

		if (componentList.Count < 1) {
			component = default;
			return false;
		}

		component = (T)componentList[0];
		return true;
	 
	 
	 
	 
	 
	 
	 
	 
	 
	 
	 */




	bool TryGetComponent<T>([MaybeNullWhen(false)] out T component) where T : IComponent {





		if (ComponentsMap.TryGetValue(typeof(T), out List<IComponent>? componentList) && componentList.Count > 0) {



		}

		component = default;
		return false;


	}

	T[] TryGetComponents<T>([MaybeNullWhen(false)] out T[] component) where T : IComponent {

		List<IComponent>? componentList;
		if (!Components.TryGetValue(typeof(T), out componentSet)) return null;



	}

	void ComponentAdded(IComponent сomponentManager) { }

	void ComponentRemoved(IComponent сomponentManager) { }


	private void AddToComponentsMap<T>(T component) where T : IComponent {
		foreach (Type type in TypeCache<T>.GetAllTypes()) {
			if (!ComponentsMap.TryGetValue(type, out List<IComponent>? componentList)) ComponentsMap[type] = componentList = [];
			componentList.Add(component);
		}

		component.ComponentAdded(this);
		ComponentAdded(component);
	}
}
