namespace UnityIceFebruary.AutoGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor;
    using UnityIceFebruary.AutoGeneration.Proxy;
    using UnityIceFebruary.AutoGeneration.Match;

    public class AutoGeneratorHandler : AssetPostprocessor
    {
        /// <summary>
        /// You can change a value of this field if you have to stop generate proxies.
        /// </summary>
        private static bool _generateCodeAutomatically = false; 
        private static void OnPostprocessAllAssets(string[] imported, string[] deleted, string[] moved, string[] movedNames)
        {
            if (!_generateCodeAutomatically || !imported.Any(p => p.EndsWith(".cs") && !p.Contains("Proxy")))
                return;

            Generate();
        }
        [MenuItem("Tools/Generate all proxies")]
        public static void Generate()
        {
            IEnumerable<Type> allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes());

            EditorApplication.delayCall += () =>
            {
                ProxyGenerator.Generate(allTypes);
                UnityMatchComponentGenerator.Generate(allTypes);
            };
        }
    }
}