using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace IUP.Toolkits.SerializableCollections.Editor
{
    public sealed class SerializableHashSetListElement : VisualElement
    {
        public SerializableHashSetListElement()
        {
            _propertyField = new PropertyField();
            Add(_propertyField);
            _helpBox = new HelpBox("The element is already in the set.", HelpBoxMessageType.Warning);
            AddToClassList("unity-list-view__reorderable-item__container");
        }

        public event Action ElementValueChanged;

        private readonly PropertyField _propertyField;
        private readonly HelpBox _helpBox;
        private bool _isWarningShown;

        public void BindProperty(SerializedProperty serializedProperty)
        {
            _propertyField.Unbind();
            _propertyField.BindProperty(serializedProperty);
            _propertyField.RegisterValueChangeCallback(InvokeElementValueChangedEvent);
        }

        public void ShowWarning()
        {
            if (!_isWarningShown)
            {
                _isWarningShown = true;
                Add(_helpBox);
            }
        }

        public void HideWarning()
        {
            if (_isWarningShown)
            {
                Remove(_helpBox);
                _isWarningShown = false;
            }
        }

        private void InvokeElementValueChangedEvent(SerializedPropertyChangeEvent context)
        {
            ElementValueChanged?.Invoke();
        }
    }
}
