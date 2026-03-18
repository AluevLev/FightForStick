namespace UnityIceFebruary.AutoGeneration
{
    using System.Linq;
    using UnityEditor;

    public class ProxyGeneratorHandler : AssetPostprocessor
    {
        /// <summary>
        /// You can change a value of this field if you have to stop generate proxies.
        /// </summary>
        private static bool _isGenerate = false; 
        private static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedNames)
        {
            if (!_isGenerate || !imported.Any(p => p.EndsWith(".cs") && !p.Contains("Proxy")))
                return;

            EditorApplication.delayCall += ProxyGenerator.Generate;
        }
    }
}