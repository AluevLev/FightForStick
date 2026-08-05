#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    public static class UnityDrawerDebugger
    {
        public static void WarnAboutUnkonwnShape() => Debugger.Log("Unknown shape!", LogType.Warning);
    }
}
#endif
