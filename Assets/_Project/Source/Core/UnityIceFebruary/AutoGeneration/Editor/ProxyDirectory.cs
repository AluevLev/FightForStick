namespace UnityIceFebruary.AutoGenerator
{
    using IceFebruary.Proxy;
    using System.IO;
    using System;
    using UnityEngine;
    using System.Collections.Generic;

    public static class ProxyDirectory
    {
        private static readonly string _autoGenerationDirectoryPath = "Auto Generated";
        private static readonly string _proxyPath = Path.Combine(_autoGenerationDirectoryPath, "Proxy");
        private static readonly string _fieldProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Field Proxy");
        private static readonly string _interfaceProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Interface Proxy");
        private static readonly string _scriptableObjectProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Scriptable Object Proxy");
        private static readonly string _staticDictionariesPath = Path.Combine(_autoGenerationDirectoryPath, "Static Dictionaries");
        private static readonly Dictionary<Type, string> _pathsOfTypes = new()
        {
            { typeof(Proxy), _proxyPath },
            { typeof(FieldProxy), _fieldProxyPath },
            { typeof(InterfaceProxy), _interfaceProxyPath },
            { typeof(ScriptableObjectProxy), _scriptableObjectProxyPath },
            { typeof(StaticProxy), _staticDictionariesPath }
        };
        public static string GetPath(Type type) => _pathsOfTypes.TryGetValue(type, out string path) ? path.GetFullDirectory() : null;
        public static void RecoveryDirectories()
        {
            RecoveryDirectory(_autoGenerationDirectoryPath);
            RecoveryDirectory(_proxyPath);
            RecoveryDirectory(_fieldProxyPath);
            RecoveryDirectory(_interfaceProxyPath);
            RecoveryDirectory(_scriptableObjectProxyPath);
            RecoveryDirectory(_staticDictionariesPath);
        }
        private static void RecoveryDirectory(string directory)
        {
            string directoryPath = directory.GetFullDirectory();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
        private static string GetFullDirectory(this string directory) => Path.Combine(Application.dataPath, directory);
    }
}
