namespace UnityIceFebruary.HelpTools
{
    using UnityEditor;
    using UnityEngine;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.HelpTools.Debuggers;

    [InitializeOnLoad]
    public static class MousePositionFinder
    {
        private static Vector2 _lastMousePosition;
        static MousePositionFinder()
        {
            SceneView.duringSceneGui += UpdateMousePosition;
        }

        [MenuItem("CONTEXT/GameObjectToolContext/Debug mouse coordinates")]
        private static void PrintWorldMousePosition(MenuCommand command)
        {
            SceneView sceneView = SceneView.lastActiveSceneView;

            if (sceneView == null)
                sceneView = SceneView.currentDrawingSceneView;

            if (sceneView == null)
            {
                MousePositionFinderDebugger.WarnAboutInsolvencyToDebugCoordinates();

                return;
            }

            Ray ray = HandleUtility.GUIPointToWorldRay(_lastMousePosition);
            Plane plane2D = new(Vector3.forward, Vector3.zero);

            if (!plane2D.Raycast(ray, out float enterDistance))
            {
                MousePositionFinderDebugger.WarnAboutInsolvencyToDebugCoordinates();

                return;
            }

            Vector3 worldMousePosition = ray.GetPoint(enterDistance);

            MousePositionFinderDebugger.DebugMousePosition(worldMousePosition.ToIce());
        }
        private static void UpdateMousePosition(SceneView sceneView)
        {
            Event currentEvent = Event.current;

            if (currentEvent != null && currentEvent.type == EventType.MouseDown)
                _lastMousePosition = currentEvent.mousePosition;
        }

    }
}