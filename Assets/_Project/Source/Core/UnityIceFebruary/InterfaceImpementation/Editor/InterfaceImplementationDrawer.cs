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
            {
                EditorGUI.LabelField(position, label.text, "Use with [SerializeReference]");
                return;
            }

            EditorGUI.BeginProperty(position, label, property);

            Rect buttonRect = new(position.x + EditorGUIUtility.labelWidth, position.y, position.width - EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);
            string fullTypeName = property.managedReferenceFullTypename;
            string typeName = "None (Null)";

            if (!string.IsNullOrEmpty(fullTypeName))
            {
                string typeWithAssembly = fullTypeName.Split(' ').Last();
                Type type = Type.GetType($"{typeWithAssembly}, {fullTypeName.Split(' ').First()}");

                typeName = type == null ? typeWithAssembly.Split('.').Last() : GetFriendlyName(type);
            }

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
            if (property.managedReferenceFullTypename == null || !property.isExpanded || string.IsNullOrEmpty(property.managedReferenceFullTypename))
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

            if (targetType.IsArray)
                targetType = targetType.GetElementType();
            else if (targetType.IsGenericType && (targetType.GetGenericTypeDefinition() == typeof(List<>)))
                targetType = targetType.GetGenericArguments()[0];

            GenericMenu menu = new();
            string path = property.propertyPath;
            UnityEngine.Object[] targets = property.serializedObject.targetObjects;

            menu.AddItem(new GUIContent("None"), false, () => Apply(targets, path, null));

            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && !type.IsAbstract);

            foreach (Type type in allTypes)
            {
                Type finalType = null;

                if (targetType.IsAssignableFrom(type))
                    finalType = type;

                else if (type.IsGenericTypeDefinition && targetType.IsGenericType)
                {
                    Type targetGenericDef = targetType.GetGenericTypeDefinition();
                    Type matchingInterface = type.GetInterfaces().FirstOrDefault(type => type.IsGenericType && type.GetGenericTypeDefinition() == targetGenericDef);

                    if (matchingInterface != null)
                    {
                        try
                        {
                            Type[] genericArgs = targetType.GetGenericArguments();
                            finalType = type.MakeGenericType(genericArgs);
                        }

                        catch { }
                    }
                }

                if (finalType != null)
                {
                    string menuName = GetFriendlyName(finalType);
                    menu.AddItem(new GUIContent(menuName), false, () => Apply(targets, path, Activator.CreateInstance(finalType)));
                }
            }

            menu.ShowAsContext();
        }

        private void Apply(UnityEngine.Object[] targets, string path, object val)
        {
            Undo.RecordObjects(targets, "Change Type");

            foreach (UnityEngine.Object obj in targets)
            {
                SerializedObject so = new(obj);
                SerializedProperty prop = so.FindProperty(path);

                if (prop != null)
                {
                    prop.managedReferenceValue = val;
                    so.ApplyModifiedProperties();
                }
            }
        }

        private string GetFriendlyName(Type type)
        {
            string typeName = type.Name;
            if (!type.IsGenericType)
                return typeName;

            string name = typeName.Split('`')[0];
            string args = string.Join(", ", type.GetGenericArguments().Select(GetFriendlyName));
            return $"{name}<{args}>";
        }
    }
}