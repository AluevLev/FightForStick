namespace UnityIceFebruary.HelpTools.AutoGenerator
{
    using System;
    using System.Linq;
    using UnityEngine;

    public static class ProxyGeneratorDebugger
    {
        public static void DebugInformationAboutProxyableTypes(Type[] proxyableTypes)
        {
            Debug.Log("Information about proxyable types:");
            Debug.Log($"Number of types: {proxyableTypes.Length}");
            Debug.Log($"Types: \n{string.Join("\n", proxyableTypes.Select(type => type.Name))}");
        }
        public static void DebugGeneratedProxy(string fileName) => Debug.Log($"Proxy generated: {fileName}");
        public static void DebugSucces() => Debug.Log("Done!");
        public static void WarnAboutProxyableAbsence() => Debug.LogWarning("No proxyable types were found!");
        public static void WarnAboutUnproxyableObject() => Debug.LogError("Cannot generate a proxy for an object with a non-proxied interface or an object that is not an interface!");
    }
}
