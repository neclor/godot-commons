using System.Diagnostics.CodeAnalysis;

namespace Neclor.Commons.Utils;


public class LimitedDict<TKey, TValue> where TKey : notnull {

	public int Count => _dictionary.Count;

	readonly int _capacity;

	readonly Dictionary<TKey, TValue> _dictionary = new();
	readonly Queue<TKey> _queue = new();

	public LimitedDict(int capacity) {
		if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
		_capacity = capacity;
	}

	public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value) {
		return _dictionary.TryGetValue(key, out value);
	}
		
	public void TryAdd(TKey key, TValue value) {
		if (_dictionary.ContainsKey(key)) return;

		if (_dictionary.Count >= _capacity) {
			TKey oldestKey = _queue.Dequeue();
			_dictionary.Remove(oldestKey);
		}

		if (_dictionary.TryAdd(key, value)) {
			_queue.Enqueue(key);
		}
	}
}
