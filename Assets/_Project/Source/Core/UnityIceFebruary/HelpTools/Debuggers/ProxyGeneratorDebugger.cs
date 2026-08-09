#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using System;
    using System.Linq;

    public static class ProxyGeneratorDebugger
    {
        public static void DebugInformationAboutProxyableTypes(Type[] proxyableTypes)
        {
            Debugger.Log("Information about proxyable types:");
            Debugger.Log($"Number of types: {proxyableTypes.Length}");
            Debugger.Log($"Types: \n{string.Join("\n", proxyableTypes.Select(type => type.Name))}");
        }
        public static void DebugGeneratedProxy(string fileName) => Debugger.Log($"Proxy generated: {fileName}");
        public static void DebugSuccess() => Debugger.Log("Done!");
        public static void WarnAboutProxyableAbsence() => Debugger.Log("No proxyable types were found!", LogType.Warning);
        public static void WarnAboutUnproxyableObject() => Debugger.Log("Cannot generate a proxy for an object with a non-proxied interface or an object that is not an interface!", LogType.Error);
    }
}
#endif
