using System;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.SerializableCollections
{
    [Serializable]
    public class SK_SV_Dictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        public Dictionary<TKey, TValue> Value => _dictionary;

        [SerializeField] private List<TKey> _keys;
        [SerializeField] private List<TValue> _values;

        private Dictionary<TKey, TValue> _dictionary = new();

        public void OnAfterDeserialize()
        {
            DictionarySerializeUtility.DeserializeDictionary(
                ref _dictionary,
                ref _keys,
                ref _values);
        }

        public void OnBeforeSerialize()
        {
            DictionarySerializeUtility.SerializeDictionary(
                ref _dictionary,
                ref _keys,
                ref _values);
        }
    }
}
