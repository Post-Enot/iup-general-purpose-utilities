using System.Collections.Generic;

namespace IUP.Toolkits
{
    public class BijectiveDictionary<TKey, TValue>
    {
        public BijectiveDictionary() { }

        public BijectiveDictionary(int capacity)
        {
            _valueByKey = new Dictionary<TKey, TValue>(capacity);
            _keyByValue = new Dictionary<TValue, TKey>(capacity);
        }

        public IReadOnlyDictionary<TKey, TValue> ValueByKey => _valueByKey;
        public IReadOnlyDictionary<TValue, TKey> KeyByValue => _keyByValue;

        private readonly Dictionary<TKey, TValue> _valueByKey = new();
        private readonly Dictionary<TValue, TKey> _keyByValue = new();

        public void Add(TKey key, TValue value)
        {
            _valueByKey.Add(key, value);
            _keyByValue.Add(value, key);
        }

        public bool Remove(TKey key, TValue value)
        {
            if (!_valueByKey.Remove(key))
            {
                return false;
            }
            return _keyByValue.Remove(value);
        }
    }
}
