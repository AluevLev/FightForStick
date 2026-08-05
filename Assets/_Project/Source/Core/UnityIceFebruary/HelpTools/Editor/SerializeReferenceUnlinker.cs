namespace UnityIceFebruary.HelpTools
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;

    public static class SerializeReferenceUnlinker
    {
        private static readonly HashSet<object> _trackedReferences = new(ReferenceEqualityComparer.Default);

        [MenuItem("CONTEXT/Component/Unlink [SerializeReference]")]
        private static void UnlinkComponentReferences(MenuCommand command) => UnlinkReferences(command);

        [MenuItem("CONTEXT/ScriptableObject/Unlink [SerializeReference]")]
        private static void UnlinkScriptableObjectReferences(MenuCommand command) => UnlinkReferences(command);

        private static void UnlinkReferences(MenuCommand command)
        {
            Object targetObject = command.context;

            if (targetObject == null)
                return;

            SerializedObject so = new(targetObject);
            SerializedProperty iterator = so.GetIterator();

            bool anyChanged = false;

            _trackedReferences.Clear();

            Undo.RecordObject(targetObject, "Unlink SerializeReference Duplicates");

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

                EditorUtility.SetDirty(targetObject);
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
