namespace UnityIceFebruary.Proxy
{
    using System.Linq;
    using UnityEditor;

    public class ProxyGeneratorHandler : AssetPostprocessor
    {
        private static bool IsGenerate = false;
        private static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedNames)
        {
            if (!IsGenerate || !imported.Any(p => p.EndsWith(".cs") && !p.Contains("Proxy")))
                return;

            EditorApplication.delayCall += ProxyGenerator.Generate;
        }
    }
}