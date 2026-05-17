namespace UnityIceFebruary.AutoGenerator
{
    using UnityEditor;
    using UnityEngine;
    using System.IO;
    using Microsoft.CodeAnalysis;
    using System.Linq;
    using System;
    using System.Reflection;
    using IceFebruary.Proxy;

    public static class ScriptGenerator
    {
        [MenuItem("Tools/Generate scripts")]
        public static void Generate()
        {
            ProxyDirectory.RecoveryDirectories();

            Assembly assembly = Assembly.Load("Assembly-CSharp");

            Type[] types = assembly.GetTypes();
            string[] fileNames = Directory.GetFiles(Application.dataPath, "*.cs", SearchOption.AllDirectories)
                .Select(path => Path.GetFileNameWithoutExtension(path))
                .ToArray();

            Type[] gameTypes = fileNames
                .Select(name => types.FirstOrDefault(type => type.Name == name))
                .Where(type => type != null)
                .ToArray();

            foreach (Type type in gameTypes)
            {
                if (type.HasAttribute<InterfaceProxy>())
                {

                }
            }
        }
        public static bool TryGetAttribute<T>(this Type type, out T attribute) where T : Attribute
        {
            attribute = type.GetCustomAttribute<T>();
            return attribute != null;
        }
        public static bool HasAttribute<T>(this Type type) where T : Attribute => type.IsDefined(typeof(T), true);
        public static bool IsProxyable(this Type type) =>
            type.HasAttribute<FieldProxy>() ||
            type.HasAttribute<InterfaceProxy>() ||
            type.HasAttribute<Proxy>() ||
            type.HasAttribute<ScriptableObjectProxy>();
    }
}
