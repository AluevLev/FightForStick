namespace UnityIceFebruary.AutoGenerator
{
    using IceFebruary.Proxy;
    using System.IO;
    using System;
    using UnityEngine;

    public static class ProxyDirectory
    {
        private static string _projectPath;
        private static readonly string _autoGenerationDirectoryPath = "Auto Generated";
        private static readonly string _proxyPath = Path.Combine(_autoGenerationDirectoryPath, "Proxy");
        private static readonly string _fieldProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Field Proxy");
        private static readonly string _unityProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Unity Proxy");
        private static readonly string _interfaceProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Interface Proxy");
        private static readonly string _scriptableObjectProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Scriptable Object Proxy");
        private static readonly string _staticDictionariesPath = Path.Combine(_autoGenerationDirectoryPath, "Static Dictionaries");
        public static string GetPath(Type type)
        {
            string path = null;

            if (type == typeof(Proxy))
                path = _proxyPath;
            if (type == typeof(FieldProxy))
                path = _fieldProxyPath;
            if (type == typeof(UnityBaseEntity<>))
                path = _unityProxyPath;
            if (type == typeof(InterfaceProxy))
                path = _interfaceProxyPath;
            if (type == typeof(ScriptableObjectProxy))
                path = _scriptableObjectProxyPath;
            
            return path.GetFullDirectory();
        }
        public static void RecoveryDirectories()
        {
            _projectPath = Application.dataPath;

            RecoveryDirectory(_autoGenerationDirectoryPath);
            RecoveryDirectory(_proxyPath);
            RecoveryDirectory(_fieldProxyPath);
            RecoveryDirectory(_unityProxyPath);
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
        private static string GetFullDirectory(this string directory) => Path.Combine(_projectPath, directory);
    }
}
