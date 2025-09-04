using System.Collections.Concurrent;
using System.Globalization;


namespace Neclor.Commons.Utils;


public static class ConcurrentMemorizer {

	static readonly ConcurrentDictionary<Delegate, ConcurrentDictionary<string, object?>> _methodsMap = new();

	public static T Call<T>(Delegate func, params object?[] args) {
		ArgumentNullException.ThrowIfNull(func, nameof(func));

		ConcurrentDictionary<string, object?> argumentsMap = _methodsMap.GetOrAdd(func, _ => new());

		string key = GetArgumentsString(args);

		object? value = argumentsMap.GetOrAdd(key, _ => func.DynamicInvoke(args));

		if (value is T valueT) return valueT;

		throw new InvalidCastException($"Cannot cast result to type {typeof(T).FullName}");
	}

	static string GetArgumentsString(object?[] args) {
		return string.Join(",", args.Select((object? arg) => arg?.GetHashCode().ToString(CultureInfo.InvariantCulture) ?? "null"));
	}

	public static void Remove(Delegate func) {
		_methodsMap.TryRemove(func, out _);
	}

	public static void Clear() {
		_methodsMap.Clear();
	}
}
