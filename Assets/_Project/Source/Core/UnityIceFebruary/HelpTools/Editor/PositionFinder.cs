namespace UnityIceFebruary.HelpTools
{
    using UnityEditor;
    using UnityEngine;

    [InitializeOnLoad]
    public static class PositionFinder
    {
        private static Vector2 _lastMousePosition;
        static PositionFinder()
        {
            SceneView.duringSceneGui += UpdateMousePosition;
        }
        private static void UpdateMousePosition(SceneView sceneView)
        {
            Event currentEvent = Event.current;

            if (currentEvent != null && currentEvent.type == EventType.MouseDown)
                _lastMousePosition = currentEvent.mousePosition;
        }

        [MenuItem("CONTEXT/GameObjectToolContext/Print coordinates")]
        private static void PrintWorldMousePosition(MenuCommand command)
        {
            SceneView sceneView = SceneView.lastActiveSceneView;

            if (sceneView == null)
                sceneView = SceneView.currentDrawingSceneView;

            if (sceneView == null)
            {
                LogError();
                return;
            }

            Ray ray = HandleUtility.GUIPointToWorldRay(_lastMousePosition);
            Plane plane2D = new(Vector3.forward, Vector3.zero);

            if (!plane2D.Raycast(ray, out float enterDistance))
            {
                LogError();
                return;
            }

            Vector3 worldPosition = ray.GetPoint(enterDistance);
            Debug.Log($"Mouse Position: ({worldPosition.x:F2}; {worldPosition.y:F2})");
        }
        private static void LogError() => Debug.LogWarning("The Scene window is not active or could not be found");
    }
}