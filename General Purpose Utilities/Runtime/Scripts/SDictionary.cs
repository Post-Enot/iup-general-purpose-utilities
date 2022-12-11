using System;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits
{
    /// <summary>
    /// Сериализуемый словарь, отображаемый в инспекторе Unity.
    /// </summary>
    /// <typeparam name="TKey">Тип ключей словаря.</typeparam>
    /// <typeparam name="TValue">Тип значений словаря.</typeparam>
    [Serializable]
    public sealed class SDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        /// <summary>
        /// Словарь.
        /// </summary>
        public IReadOnlyDictionary<TKey, TValue> Value => _value;

        private Dictionary<TKey, TValue> _value;
        [SerializeField] private List<SKeyValuePair<TKey, TValue>> _pairs;

        /// <summary>
        /// Не использовать, если не знаете, что делаете. Метод обратного вызова после десериализации.
        /// </summary>
        public void OnAfterDeserialize()
        {
            _value = new Dictionary<TKey, TValue>(_pairs.Count);
            for (int i = 0; i < _pairs.Count; i += 1)
            {
                if (!_value.ContainsKey(_pairs[i].Key))
                {
                    _value.Add(_pairs[i].Key, _pairs[i].Value);
                }
            }
        }

        /// <summary>
        /// Не использовать, если не знаете, что делаете. Метод обратного вызова перед сериализацией.
        /// </summary>
        public void OnBeforeSerialize() { }
    }
}
