using UnityEngine;
using System;

namespace IUP.Toolkits
{
    /// <summary>
    /// Пара ключ-значение для десериализуемого словаря.
    /// </summary>
    /// <typeparam name="TKey">Тип ключа пары.</typeparam>
    /// <typeparam name="TValue">Тип значения пары.</typeparam>
    [Serializable]
    public class SKeyValuePair<TKey, TValue>
    {
        public SKeyValuePair(TKey key = default, TValue value = default)
        {
            _key = key;
            _value = value;
        }

        /// <summary>
        /// Ключ.
        /// </summary>
        public TKey Key => _key;
        /// <summary>
        /// Значение.
        /// </summary>
        public TValue Value => _value;

        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;
    }
}
