namespace UnityIceFebruary.HelpTools
{
    using IceFebruary.Space;
    using UnityEditor;
    using UnityEngine;

    public sealed class AngleToRotorConverter : EditorWindow
    {
        private float _inputAngle;
        private Rotor2 _carculatedRotor;

        [MenuItem("Tools/Angle to rotor converter")]
        public static void ShowWindow()
        {
            AngleToRotorConverter window = GetWindow<AngleToRotorConverter>("Angle to rotor converter");
            window.minSize = new(300, 150);
        }
        private void OnGUI()
        {
            GUILayout.Label("Angle to rotor converter", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUI.BeginChangeCheck();
            _inputAngle = EditorGUILayout.FloatField("Angle:", _inputAngle);

            if (EditorGUI.EndChangeCheck())
                _carculatedRotor = new(_inputAngle, false);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Result:", EditorStyles.boldLabel, GUILayout.Width(110));
            EditorGUILayout.SelectableLabel($"Scalar: {_carculatedRotor.Scalar}", EditorStyles.textField, GUILayout.Height(18));
            EditorGUILayout.SelectableLabel($"XY: {_carculatedRotor.XY}", EditorStyles.textField, GUILayout.Height(18));
        }
    }
}
