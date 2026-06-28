namespace UnityIceFebruary.InterfaceImplementation
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;

    public static class SerializeReferenceUnlinker
    {
        private static readonly HashSet<object> _trackedReferences = new(ReferenceEqualityComparer.Default);

        [MenuItem("CONTEXT/Component/Unlink [SerializeReference]")]
        private static void UnlinkReferences(MenuCommand command)
        {
            Component component = command.context as Component;

            if (component == null)
                return;

            SerializedObject so = new(component);
            SerializedProperty iterator = so.GetIterator();
            bool anyChanged = false;

            _trackedReferences.Clear();

            Undo.RecordObject(component, "Unlink SerializeReference Duplicates");

            while (iterator.NextVisible(true))
            {
                if (iterator.propertyType != SerializedPropertyType.ManagedReference)
                    continue;

                object currentRefValue = iterator.managedReferenceValue;

                if (currentRefValue == null)
                    continue;

                if (!_trackedReferences.Add(currentRefValue))
                {
                    string jsonState = JsonUtility.ToJson(currentRefValue);
                    object uniqueClone = JsonUtility.FromJson(jsonState, currentRefValue.GetType());

                    iterator.managedReferenceValue = uniqueClone;
                    anyChanged = true;
                }
            }

            if (anyChanged)
            {
                so.ApplyModifiedProperties();
                EditorUtility.SetDirty(component);
            }
        }

        private class ReferenceEqualityComparer : IEqualityComparer<object>
        {
            public new bool Equals(object x, object y) => ReferenceEquals(x, y);
            public int GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
            public static ReferenceEqualityComparer Default { get; } = new ReferenceEqualityComparer();
        }
    }
}
