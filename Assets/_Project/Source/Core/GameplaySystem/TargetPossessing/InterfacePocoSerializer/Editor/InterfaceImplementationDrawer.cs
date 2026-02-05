using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[CustomPropertyDrawer(typeof(InterfaceImplementation))]
public class InterfaceImplementationDrawer : PropertyDrawer
{
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

            float currentY = position.y + EditorGUIUtility.singleLineHeight + 2;

            while (!SerializedProperty.EqualContents(child, endProperty))
            {
                float height = EditorGUI.GetPropertyHeight(child, true);
                Rect childRect = new(position.x, currentY, position.width, height);

                EditorGUI.PropertyField(childRect, child, true);

                currentY += height + 2;
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
            height += EditorGUI.GetPropertyHeight(child, true) + 2;
            if (!child.NextVisible(false))
                break;
        }

        return height;
    }

    private void ShowTypeMenu(SerializedProperty property)
    {
        Type targetType = fieldInfo.FieldType;
        if (targetType.IsGenericType) targetType = targetType.GetGenericArguments()[0];

        GenericMenu menu = new();
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => targetType.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

        string path = property.propertyPath;
        var targets = property.serializedObject.targetObjects;

        menu.AddItem(new GUIContent("None"), false, () => Apply(targets, path, null));
        foreach (var t in types)
            menu.AddItem(new GUIContent(t.Name), false, () => Apply(targets, path, Activator.CreateInstance(t)));
        menu.ShowAsContext();
    }

    private void Apply(UnityEngine.Object[] targets, string path, object val)
    {
        Undo.RecordObjects(targets, "Change Type");

        foreach (var obj in targets)
        {
            SerializedObject so = new(obj);
            so.FindProperty(path).managedReferenceValue = val;
            so.ApplyModifiedProperties();
        }
    }
}