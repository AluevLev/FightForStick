#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using UnityEngine;
    using UnityIceFebruary.Adaptation;

    using IceVector2 = IceFebruary.Space.Vector2;

    public static class Debugger
    {
        public static void LogMessage(string message) => Debug.Log(message);
        public static void LogWarning(string warning) => Debug.LogWarning(warning);
        public static void LogError(string error) => Debug.LogError(error);
        public static void DrawLine(IceVector2 a, IceVector2 b, float duration) => Debug.DrawLine(a.ToUnity(), b.ToUnity(), Color.green, duration);
    }
}
#endif
