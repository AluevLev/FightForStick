#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using UnityEngine;
    using UnityIceFebruary.Adaptation;

    using IceVector2 = IceFebruary.Space.Vector2;

    public static class Debugger
    {
        public static void Log(string message, LogType logType = LogType.Message)
        {
            switch (logType)
            {
                case LogType.Message:
                    Debug.Log(message);
                    break;

                case LogType.Warning:
                    Debug.LogWarning(message);
                    break;

                case LogType.Error:
                    Debug.LogError(message);
                    break;
            }
        }
        public static void DrawLine(IceVector2 a, IceVector2 b, float duration) => Debug.DrawLine(a.ToUnity(), b.ToUnity(), Color.green, duration);
    }
    public enum LogType
    {
        Message,
        Warning,
        Error
    }
}
#endif
