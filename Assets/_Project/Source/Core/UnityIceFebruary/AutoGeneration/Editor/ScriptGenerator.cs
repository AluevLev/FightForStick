namespace UnityIceFebruary.AutoGenerator
{
    using UnityEngine;
    using UnityEditor;
    using System.IO;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis;
    using System.Collections.Generic;
    using System.Linq;
    using IceFebruary.Proxy;

    public static class ScriptGenerator
    {
        [MenuItem("Tools/Generate scripts")]
        public static void Generate()
        {
            ProxyDirectory.RecoveryDirectories();

            string[] files = Directory.GetFiles(ProxyDirectory.ProjectPath, "*.cs", SearchOption.AllDirectories);
            List<string> proxyCode = new();

            foreach (string file in files)
                if (file.TryFindGenerableProxies(out string code))
                    proxyCode.Add(file);
        }
        private static bool TryFindGenerableProxies(this string file, out string code)
        {
            code = null;
            string text = File.ReadAllText(file);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(text);
            IEnumerable<SyntaxNode> syntax = tree.GetRoot().DescendantNodes();

            IEnumerable<AttributeSyntax> attributes = syntax.OfType<AttributeSyntax>();

            foreach (AttributeSyntax attribute in attributes)
            {
                switch (attribute.Name.ToString())
                {
                    case nameof(InterfaceProxy):
                        code = ProxyBuilder.GenerateInterfaceProxyCode(syntax);
                        break;
                }
            }

            return !string.IsNullOrWhiteSpace(code);
        }
        
    }
}
