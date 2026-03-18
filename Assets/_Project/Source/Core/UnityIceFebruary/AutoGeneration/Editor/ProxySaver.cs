namespace UnityIceFebruary.AutoGeneration
{
    using System;
    using System.IO;
    using System.Text;
    using UnityEngine;

    public static class ProxySaver
    {
        private static readonly string _savePath = "ProxyGenerated";
        public static void SaveProxy(StringBuilder stringBuilder, Type classProxy)
        {
            string dir = Path.Combine(Application.dataPath, _savePath);
            string path = Path.Combine(dir, $"{classProxy.GetProxyName()}.cs");

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string content = stringBuilder.ToString();

            if (File.Exists(path) && File.ReadAllText(path) == content)
                return;

            File.WriteAllText(path, content);
        }
    }
}
