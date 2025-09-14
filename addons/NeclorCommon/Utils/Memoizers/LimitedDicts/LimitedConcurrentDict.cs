using System.Collections.Concurrent;


namespace Neclor.Commons.Utils;


public class LimitedConcurrentDict<TKey, TValue> where TKey : notnull {

	public int Count => _dictionary.Count;

	readonly int _capacity;

	readonly ConcurrentDictionary<TKey, TValue> _dictionary = new();
	readonly Queue<TKey> _queue = new();

	private Lock _gate = new Lock();

	public LimitedConcurrentDict(int capacity) {
		if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
		_capacity = capacity;
	}

	public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory) {
		ArgumentNullException.ThrowIfNull(key);
		ArgumentNullException.ThrowIfNull(valueFactory);

		TValue? value;
		if (_dictionary.TryGetValue(key, out value)) return value;

		value = valueFactory(key);

		lock (_gate) {
			if (_dictionary.Count >= _capacity) {
				TKey oldestKey = _queue.Dequeue();
				_dictionary.TryRemove(oldestKey, out _);
			}

			if (_dictionary.TryAdd(key, value)) {
				_queue.Enqueue(key);
			}
		}

		return value;
	}
}
