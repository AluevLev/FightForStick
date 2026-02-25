using UnityEngine;
using UnityEditor;
using System.Linq;

public class ProxyGenerator : AssetPostprocessor
{
	/*
	private static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedNames)
	{
		if (imported.Any(p => p.EndsWith(".cs") && !p.Contains("Proxy")))
			EditorApplication.delayCall += Generate;
	}
	public string void Generate()
	{

	}
	*/
}
