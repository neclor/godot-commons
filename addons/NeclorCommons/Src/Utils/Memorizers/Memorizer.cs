using System.Globalization;


namespace Neclor.Commons.Utils;


public static class Memorizer {

	const int MaxEntriesPerMethod = 128;

	static readonly Dictionary<Delegate, LimitedDict<string, object?>> _methodsMap = new();

	public static T Call<T>(Delegate func, params object?[] args) {
		ArgumentNullException.ThrowIfNull(func, nameof(func));

		LimitedDict<string, object?>? argumentsMap;

		if (!_methodsMap.TryGetValue(func, out argumentsMap)) _methodsMap[func] = argumentsMap = new(MaxEntriesPerMethod);
		
		string key = GetArgumentsString(args);
		object? value;

		if (!argumentsMap.TryGetValue(key, out value)) {
			value = func.DynamicInvoke(args);
			argumentsMap.TryAdd(key, value);
		}

		if (value is T valueT) return valueT;

		throw new InvalidCastException($"Cannot cast result to type {typeof(T).FullName}");
	}

	static string GetArgumentsString(object?[] args) {
		return string.Join(",", args.Select((object? arg) => arg?.GetHashCode().ToString(CultureInfo.InvariantCulture) ?? "null"));
	}

	public static void Remove(Delegate func) {
		_methodsMap.Remove(func);
	}

	public static void Clear() {
		_methodsMap.Clear();
	}
}
