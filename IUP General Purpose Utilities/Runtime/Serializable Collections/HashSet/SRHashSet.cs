using System;
using System.Collections.Generic;
using UnityEngine;

namespace IUP.Toolkits.SerializableCollections
{
    [Serializable]
    public class SRHashSet<T>
    {
        public SRHashSet()
        {
            _serializationShell = new(OnAfterDeserialize, OnBeforeSerialize);
        }

        public HashSet<T> Value { get; private set; } = new();

        [SerializeReference] private List<T> _elements;
        [SerializeField] private CustomSerializationShell _serializationShell;

        private void OnAfterDeserialize()
        {
            Value = new HashSet<T>(_elements);
        }

        private void OnBeforeSerialize()
        {
            _elements = new List<T>(Value);
        }
    }
}
