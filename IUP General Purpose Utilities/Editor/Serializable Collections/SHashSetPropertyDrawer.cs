using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UIElements;

namespace IUP.Toolkits.SerializableCollections.Editor
{
    [CustomPropertyDrawer(typeof(SHashSet<>), true)]
    public sealed class SHashSetPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new();
            SerializedProperty bindedListProperty =
                property.FindPropertyRelative("_elementsSerializedByInspector");

            VisualElement MakeItem()
            {
                SerializableHashSetListElement hashSetListElement = new();
                VisualElement elementContainer = new();
                elementContainer.Add(hashSetListElement);
                return elementContainer;
            }

            void BindItem(VisualElement visualElement, int index)
            {
                bindedListProperty.serializedObject.Update();
                SerializableHashSetListElement listElement =
                    visualElement.Q<SerializableHashSetListElement>();
                listElement.BindProperty(bindedListProperty.GetArrayElementAtIndex(index));
                listElement.ElementValueChanged += () => UpdateItem(listElement, index);
                UpdateItem(listElement, index);
            }

            void UpdateItem(SerializableHashSetListElement listElement, int index)
            {
                bindedListProperty.serializedObject.Update();
                HashSet<int> dublicateElementIndexes = GetDublicateElementIndexes(property);
                if (dublicateElementIndexes.Contains(index))
                {
                    listElement.ShowWarning();
                }
                else
                {
                    listElement.HideWarning();
                }
            }

            List<object> fakeElementList = CreateFakeElementList(bindedListProperty);
            ListView listView = new(fakeElementList, makeItem: MakeItem, bindItem: BindItem)
            {
                reorderable = true,
                showAddRemoveFooter = true,
                showFoldoutHeader = true,
                showBoundCollectionSize = true,
                showBorder = true,
                selectionType = SelectionType.Multiple,
                virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight,
                headerTitle = property.displayName,
                reorderMode = ListViewReorderMode.Animated
            };

            listView.itemsAdded += (IEnumerable<int> indexes) =>
            {
                foreach (int index in indexes)
                {
                    bindedListProperty.InsertArrayElementAtIndex(index);
                }
                bindedListProperty.serializedObject.ApplyModifiedProperties();
            };
            listView.itemsRemoved += (IEnumerable<int> indexes) =>
            {
                List<int> indexesList = new(indexes);
                indexesList.Reverse();
                foreach (int index in indexesList)
                {
                    bindedListProperty.DeleteArrayElementAtIndex(index);
                }
                bindedListProperty.serializedObject.ApplyModifiedProperties();
            };
            listView.itemIndexChanged += (int from, int to) =>
            {
                _ = bindedListProperty.MoveArrayElement(from, to);
                bindedListProperty.serializedObject.ApplyModifiedProperties();
            };

            root.Add(listView);
            return root;
        }

        private List<object> CreateFakeElementList(SerializedProperty bindedListProperty)
        {
            List<object> fakeElementList = new();
            for (int i = 0; i < bindedListProperty.arraySize; i += 1)
            {
                fakeElementList.Add(new());
            }
            return fakeElementList;
        }

        private HashSet<int> GetDublicateElementIndexes(SerializedProperty property)
        {
            SerializedProperty dublicateElementIndexesProperty =
                property.FindPropertyRelative("_dublicateElementIndexes");
            HashSet<int> dublicateElementIndexes = new();
            for (int i = 0; i < dublicateElementIndexesProperty.arraySize; i += 1)
            {
                SerializedProperty dublicateElementIndexProperty =
                    dublicateElementIndexesProperty.GetArrayElementAtIndex(i);
                _ = dublicateElementIndexes.Add(dublicateElementIndexProperty.intValue);
            }
            return dublicateElementIndexes;
        }
    }
}
