using System;
using UnityEngine;

namespace IUP.Toolkits
{
    [Serializable]
    public sealed class CustomSerializationShell : ISerializationCallbackReceiver
    {
        public CustomSerializationShell(Action onAfterDeserialize, Action onBeforeSerialize)
        {
            _onAfterDeserialize = onAfterDeserialize;
            _onBeforeDeserialize = onBeforeSerialize;
        }

        private readonly Action _onAfterDeserialize;
        private readonly Action _onBeforeDeserialize;

        public void OnAfterDeserialize()
        {
            _onAfterDeserialize();
        }

        public void OnBeforeSerialize()
        {
            _onBeforeDeserialize();
        }
    }
}
