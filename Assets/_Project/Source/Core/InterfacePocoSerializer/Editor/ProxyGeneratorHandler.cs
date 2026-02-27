using System.Linq;
using UnityEditor;

public class ProxyGeneratorHandler : AssetPostprocessor
{
    private static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedNames)
    {
        if (imported.Any(p => p.EndsWith(".cs") && !p.Contains("Proxy")))
            EditorApplication.delayCall += ProxyGenerator.Generate;
    }
}
