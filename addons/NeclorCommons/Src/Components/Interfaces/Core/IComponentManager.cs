using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Neclor.Commons.Components.Interfaces.Core;


public interface IComponentManager {


	protected abstract Dictionary<Type, List<IComponent>> Components { get; }



	ReadOnlyCollection<T> GetComponent<T>() where T : IComponent {
		return new ReadOnlyCollection<T>(
			Components.TryGetValue(typeof(T), out List<IComponent>? list) ? list.Cast<T>().ToList() : new List<T>()
		);
	}


	void AddComponent(IComponent component) {


		Components.TryGetValue(typeof(component.type))



		component.ComponentOwner = this;
	}


	bool HasComponent<T>() where T : IComponent;



	bool RemoveComponent<T>() where T : class, IComponent;





	extension(object obj) {




	}

	public static List<Type> GetAllTypes(object obj) {
		if (obj == null) throw new ArgumentNullException(nameof(obj));

		var result = new List<Type>();
		Type type = obj.GetType();

		// Добавляем сам тип
		result.Add(type);

		// Добавляем базовые классы
		Type current = type.BaseType;
		while (current != null) {
			result.Add(current);
			current = current.BaseType;
		}

		// Добавляем интерфейсы (уникальные)
		foreach (var iface in type.GetInterfaces()) {
			if (!result.Contains(iface))
				result.Add(iface);
		}

		return result;
	}









}
