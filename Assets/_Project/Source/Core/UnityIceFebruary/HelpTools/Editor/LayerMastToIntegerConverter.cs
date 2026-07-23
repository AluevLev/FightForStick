namespace UnityIceFebruary.HelpTools
{
    using UnityEditor;
    using UnityEngine;

    public sealed class LayerMastToIntegerConverter : EditorWindow
    {
        private LayerMask _selectedLayers;

        [MenuItem("Tools/LayerMask to int converter")]
        public static void ShowWindow()
        {
            LayerMastToIntegerConverter window = GetWindow<LayerMastToIntegerConverter>("LayerMask to int converter");
            window.minSize = new(300, 100);
        }

        private void OnGUI()
        {
            GUILayout.Label("LayerMask to int converter", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            _selectedLayers = EditorGUILayoutLayerMaskField("Layers:", _selectedLayers);

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Result:", EditorStyles.boldLabel, GUILayout.Width(110));
            EditorGUILayout.SelectableLabel(_selectedLayers.value.ToString(), EditorStyles.textField, GUILayout.Height(18));
        }

        private LayerMask EditorGUILayoutLayerMaskField(string label, LayerMask layerMask)
        {
            string[] layerNames = UnityEditorInternal.InternalEditorUtility.layers;
            return EditorGUILayout.MaskField(label, layerMask.value, layerNames);
        }
    }
}
