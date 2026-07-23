namespace UnityIceFebruary.HelpTools
{
    using UnityEditor;
    using UnityEngine;

    public sealed class AnimatorHashTool : EditorWindow
    {
        private string _inputText;
        private int _calculatedHash;

        [MenuItem("Tools/Animator hash tool")]
        public static void ShowWindow()
        {
            AnimatorHashTool window = GetWindow<AnimatorHashTool>("Hash Tool");
            window.minSize = new(300, 100);
        }
        private void OnGUI()
        {
            GUILayout.Label("Hash Generator for Animator", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            _inputText = EditorGUILayout.TextField("Field name:", _inputText);

            if (EditorGUI.EndChangeCheck() || _calculatedHash == 0)
                _calculatedHash = Animator.StringToHash(_inputText);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Result:", EditorStyles.boldLabel, GUILayout.Width(110));
            EditorGUILayout.SelectableLabel(_calculatedHash.ToString(), EditorStyles.textField, GUILayout.Height(18));
        }
    }
}
