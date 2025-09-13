using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.ComponentModel;


namespace Neclor.Commons.Extensions;


public static class TypeCache {

	private static readonly Dictionary<Type, TypeCacheEntry> _typeCache = new();

	public static Type[] GetInterfaces(Type type) {
		ArgumentNullException.ThrowIfNull(type);

		if (!_typeCache.TryGetValue(type, out TypeCacheEntry? entry)) _typeCache[type] = entry = new();
		if (entry.interfaces is null) entry.interfaces = type.GetInterfaces();

		return (Type[])entry.interfaces.Clone();
	}

	public static Type[] GetInterfaces<T>() {
		return GetInterfaces(typeof(T));
	}

	public static Type[] GetBaseTypes(Type type) {
		ArgumentNullException.ThrowIfNull(type);

		if (!_typeCache.TryGetValue(type, out TypeCacheEntry? entry)) _typeCache[type] = entry = new();
		if (entry.baseTypes is null) entry.baseTypes = type.GetBaseTypes();

		return (Type[])entry.baseTypes.Clone();
	}

	public static Type[] GetBaseTypes<T>() {
		return GetBaseTypes(typeof(T));
	}

	public static Type[] GetAllTypes(Type type) {
		ArgumentNullException.ThrowIfNull(type);

		if (!_typeCache.TryGetValue(type, out TypeCacheEntry? entry)) _typeCache[type] = entry = new();
		if (entry.allTypes is null) entry.allTypes = type.GetAllTypes();

		return (Type[])entry.allTypes.Clone();
	}

	public static Type[] GetAllTypes<T>() {
		return GetAllTypes(typeof(T));
	}

	private class TypeCacheEntry {
		public Type[]? interfaces;
		public Type[]? baseTypes;
		public Type[]? allTypes;
	}
}
