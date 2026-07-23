#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    public static class UnityDrawerDebugger
    {
        public static void WarnAboutUnkonwnShape() => Debugger.LogWarning("Unknown shape!");
    }
}
#endif
