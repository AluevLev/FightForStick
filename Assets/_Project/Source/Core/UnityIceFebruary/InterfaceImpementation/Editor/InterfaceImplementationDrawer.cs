namespace UnityIceFebruary.InterfaceImplementation
{
    using UnityEngine;
    using UnityEditor;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [CustomPropertyDrawer(typeof(InterfaceImplementation))]
    public sealed class InterfaceImplementationDrawer : PropertyDrawer
    {
        private readonly int spacing = 2;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.managedReferenceFullTypename == null)
                return;

            EditorGUI.BeginProperty(position, label, property);

            Rect buttonRect = new(position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);

            string fullTypeName = property.managedReferenceFullTypename;
            string typeName = string.IsNullOrEmpty(fullTypeName) ? "None (Null)" : fullTypeName.Split(' ').Last();

            if (GUI.Button(buttonRect, typeName, EditorStyles.miniPullDown))
                ShowTypeMenu(property);

            property.isExpanded = EditorGUI.Foldout(new(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), property.isExpanded, label, true);

            if (property.isExpanded && !string.IsNullOrEmpty(fullTypeName))
            {
                EditorGUI.indentLevel++;

                SerializedProperty child = property.Copy();
                SerializedProperty endProperty = child.GetEndProperty();

                child.NextVisible(true);

                float currentY = position.y + EditorGUIUtility.singleLineHeight + spacing;

                while (!SerializedProperty.EqualContents(child, endProperty))
                {
                    float height = EditorGUI.GetPropertyHeight(child, true);

                    Rect childRect = new(position.x, currentY, position.width, height);

                    EditorGUI.PropertyField(childRect, child, true);

                    currentY += height + spacing;

                    if (!child.NextVisible(false))
                        break;
                }

                EditorGUI.indentLevel--;
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (!property.isExpanded || string.IsNullOrEmpty(property.managedReferenceFullTypename))
                return EditorGUIUtility.singleLineHeight;

            float height = EditorGUIUtility.singleLineHeight;

            SerializedProperty child = property.Copy();
            SerializedProperty endProperty = child.GetEndProperty();

            child.NextVisible(true);

            while (!SerializedProperty.EqualContents(child, endProperty))
            {
                height += EditorGUI.GetPropertyHeight(child, true) + spacing;
                if (!child.NextVisible(false))
                    break;
            }

            return height;
        }

        private void ShowTypeMenu(SerializedProperty property)
        {
            Type targetType = fieldInfo.FieldType;

            if (targetType.IsGenericType)
                targetType = targetType.GetGenericArguments()[0];

            GenericMenu menu = new();

            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(Type => targetType.IsAssignableFrom(Type) && Type.IsClass && !Type.IsAbstract);

            string path = property.propertyPath;

            UnityEngine.Object[] targets = property.serializedObject.targetObjects;

            menu.AddItem(new GUIContent("None"), false, () => Apply(targets, path, null));

            foreach (Type type in types)
                menu.AddItem(new GUIContent(type.Name), false, () => Apply(targets, path, Activator.CreateInstance(type)));

            menu.ShowAsContext();
        }

        private void Apply(UnityEngine.Object[] targets, string path, object val)
        {
            Undo.RecordObjects(targets, "Change Type");

            foreach (UnityEngine.Object obj in targets)
            {
                SerializedObject so = new(obj);

                so.FindProperty(path).managedReferenceValue = val;
                so.ApplyModifiedProperties();
            }
        }
    }
}