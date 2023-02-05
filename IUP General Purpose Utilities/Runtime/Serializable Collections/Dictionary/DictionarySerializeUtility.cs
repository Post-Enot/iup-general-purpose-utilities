using System.Collections.Generic;

namespace IUP.Toolkits.SerializableCollections
{
    public static class DictionarySerializeUtility
    {
        public static void SerializeDictionary<TKey, TValue>(
            ref Dictionary<TKey, TValue> dictionary,
            ref List<TKey> keys,
            ref List<TValue> values)
        {
            keys = new List<TKey>(dictionary.Count);
            values = new List<TValue>(dictionary.Count);
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public static void DeserializeDictionary<TKey, TValue>(
            ref Dictionary<TKey, TValue> dictionary,
            ref List<TKey> keys,
            ref List<TValue> values)
        {
            dictionary = new Dictionary<TKey, TValue>(keys.Count);
            for (int i = 0; i < keys.Count; i += 1)
            {
                if (!dictionary.ContainsKey(keys[i]))
                {
                    dictionary.Add(keys[i], values[i]);
                }
            }
        }
    }
}
