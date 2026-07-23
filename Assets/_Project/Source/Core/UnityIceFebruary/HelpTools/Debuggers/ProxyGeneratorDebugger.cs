#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using System;
    using System.Linq;

    public static class ProxyGeneratorDebugger
    {
        public static void DebugInformationAboutProxyableTypes(Type[] proxyableTypes)
        {
            Debugger.LogMessage("Information about proxyable types:");
            Debugger.LogMessage($"Number of types: {proxyableTypes.Length}");
            Debugger.LogMessage($"Types: \n{string.Join("\n", proxyableTypes.Select(type => type.Name))}");
        }
        public static void DebugGeneratedProxy(string fileName) => Debugger.LogMessage($"Proxy generated: {fileName}");
        public static void DebugSucces() => Debugger.LogMessage("Done!");
        public static void WarnAboutProxyableAbsence() => Debugger.LogWarning("No proxyable types were found!");
        public static void WarnAboutUnproxyableObject() => Debugger.LogError("Cannot generate a proxy for an object with a non-proxied interface or an object that is not an interface!");
    }
}
#endif
