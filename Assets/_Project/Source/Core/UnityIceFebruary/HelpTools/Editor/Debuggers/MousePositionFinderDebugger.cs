namespace UnityIceFebruary.HelpTools.Debuggers
{
    using UnityEngine;

    public static class MousePositionFinderDebugger
    {
        public static void DebugMousePosition(Vector2 position) => Debug.Log($"Mouse Position: ({position.x:F2}; {position.y:F2})");
        public static void WarnAboutInsolvencyToDebugCoordinates() => Debug.LogWarning("The scene window is not active or could not be found");
    }
}
