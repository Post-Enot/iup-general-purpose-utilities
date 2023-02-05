using System;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.SerializableCollections
{
    [Serializable]
    public class SHashSet<T> : ISerailizableHashSetBase<T>
    {
        public SHashSet()
        {
            _serializationShell = new(OnAfterDeserialize, OnBeforeSerialize);
        }

        public HashSet<T> Value { get; private set; } = new();

        [SerializeField] private List<T> _elements;
        [SerializeField] private CustomSerializationShell _serializationShell;

#if UNITY_EDITOR
        [SerializeField] private List<T> _elementsSerializedByInspector;
        [SerializeField] private List<int> _dublicateElementIndexes;
#endif

        private void OnAfterDeserialize()
        {
            Value = new HashSet<T>(_elements);
#if UNITY_EDITOR
            _elementsSerializedByInspector = new List<T>(Value);
#endif
        }

        private void OnBeforeSerialize()
        {
            _elements = new List<T>(Value);
#if UNITY_EDITOR
            Value.Clear();
            HashSet<T> dublicatedElements = new();
            _dublicateElementIndexes = new List<int>();
            _elementsSerializedByInspector ??= new List<T>();
            for (int i = 0; i < _elementsSerializedByInspector.Count; i += 1)
            {
                T element = _elementsSerializedByInspector[i];
                _ = Value.Add(element);
                bool isAdded = dublicatedElements.Add(element);
                if (!isAdded)
                {
                    _dublicateElementIndexes.Add(i);
                }
            }
#endif
        }
    }
}
