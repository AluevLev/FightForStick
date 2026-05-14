namespace UnityIceFebruary.AutoGenerator
{
    using UnityEngine;
    using System.IO;

    public static class ProxyDirectory
    {
        public static string ProjectPath { get; private set; }
        private static readonly string _autoGenerationDirectoryPath = "Auto Generated";
        private static readonly string _proxyPath = Path.Combine(_autoGenerationDirectoryPath, "Proxy");
        private static readonly string _fieldProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Field Proxy");
        private static readonly string _interfaceProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Interface Proxy");
        private static readonly string _scriptableObjectProxyPath = Path.Combine(_autoGenerationDirectoryPath, "Scriptable Object Proxy");
        private static readonly string _staticDictionariesPath = Path.Combine(_autoGenerationDirectoryPath, "Static Dictionaries");
        public static void RecoveryDirectories()
        {
            ProjectPath = Application.dataPath;

            RecoveryDirectory(_autoGenerationDirectoryPath);
            RecoveryDirectory(_proxyPath);
            RecoveryDirectory(_fieldProxyPath);
            RecoveryDirectory(_interfaceProxyPath);
            RecoveryDirectory(_scriptableObjectProxyPath);
            RecoveryDirectory(_staticDictionariesPath);
        }
        private static void RecoveryDirectory(string directory)
        {
            string directoryPath = Path.Combine(ProjectPath, directory);

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}
