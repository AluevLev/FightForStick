namespace UnityIceFebruary.HelpTools.MousePositionFinder
{
    using UnityEngine;

    public static class MousePositionFinderDebugger
    {
        public static void WarnAboutInsolvencyToDebugCoordinates() => Debug.LogWarning("The scene window is not active or could not be found");
        public static void DebugMousePosition(Vector2 position) => Debug.Log($"Mouse Position: ({position.x:F2}; {position.y:F2})");
    }
}
