using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
[CustomEditor(typeof(TargetPossessing))]
[CanEditMultipleObjects]
public class TargetPossessingEditor : Editor
{
    [SerializeField] private VisualTreeAsset visualTree;
    public override VisualElement CreateInspectorGUI()
    {
        VisualElement root = new();

        visualTree.CloneTree(root);

        PropertyField angleField = root.Q<PropertyField>("StartAngleField");
        PropertyField directionField = root.Q<PropertyField>("StartDirectionField");
        PropertyField transformField = root.Q<PropertyField>("StartTransformField");

        SerializedProperty typeProperty = serializedObject.FindProperty("_startTarget");

        root.TrackPropertyValue(typeProperty, (p) => Refresh(p, angleField, directionField, transformField));

        Refresh(typeProperty, angleField, directionField, transformField);

        root.Bind(serializedObject);

        return root;
    }
    private void Refresh(SerializedProperty property, VisualElement angleField, PropertyField directionField, PropertyField transformField)
    {
        if (property.hasMultipleDifferentValues)
        {
            angleField.style.display = DisplayStyle.Flex;
            directionField.style.display = DisplayStyle.Flex;
            transformField.style.display = DisplayStyle.Flex;
            return;
        }

        TargetType targetType = (TargetType)property.enumValueIndex;

        angleField.style.display = targetType == TargetType.Angle ? DisplayStyle.Flex : DisplayStyle.None;
        directionField.style.display = targetType == TargetType.Direction ? DisplayStyle.Flex : DisplayStyle.None;
        transformField.style.display = targetType == TargetType.Transform ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
