using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class ProxyGenerator
{
	[MenuItem("Tools/Generate all proxies")]
	public static void Generate()
	{
        Debug.Log($"Найдено сборок: {AppDomain.CurrentDomain.GetAssemblies().Length}");

        IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsProxyable());

		foreach (var type in types)
		{
			ConstructorInfo constructor = type.GetConstructors().First(c => c.HasGenerateProxyAttribute());
            ParameterInfo[] parameters = constructor.GetParameters();

            bool useGeneric = parameters.Any(f => f.ParameterType.IsGenericType);
            bool isListPresent = parameters.Any(f => f.ParameterType.IsGenericType && f.ParameterType.GetGenericTypeDefinition() == typeof(List<>));
            bool isArrayPresent = parameters.Any(f => f.ParameterType.IsArray);
            bool useLinq = isListPresent || isArrayPresent;

            StringBuilder proxySringBuilder = new();

            proxySringBuilder.AppendLine("// AUTO-GENERATED. DO NOT EDIT.");
            proxySringBuilder.AppendLine("using System;");
            proxySringBuilder.AppendLine("using UnityEngine;");

            if (useGeneric)
                proxySringBuilder.AppendLine("using System.Collections.Generic;");

            if (useLinq)
                proxySringBuilder.AppendLine("using System.Linq;");

            proxySringBuilder.AppendLine("");
            proxySringBuilder.AppendLine("[Serializable]");
            proxySringBuilder.AppendLine($"public class {type.Name}Proxy");
            proxySringBuilder.AppendLine("{");

            foreach (var p in parameters)
            {
                string typeName = GetSafetyTypeName(p.ParameterType);
                string initializer = p.ParameterType.IsList() ? " = new()" : "";

                bool isInterface = p.ParameterType.IsInterface || p.ParameterType.IsAbstract;
                string attribute = isInterface ? "    [SerializeReference, InterfaceImplementation]" : "    [SerializeField]";

                proxySringBuilder.AppendLine($"{attribute} private {typeName} _{p.Name};");
            }

            proxySringBuilder.AppendLine("");

            proxySringBuilder.Append($"    public {type.Name} ToPoco() => new(");

            IEnumerable<string> constructorValues = parameters.Select(p => {
                Type t = p.ParameterType;

                if (t.IsProxyable())
                    return $"_{p.Name}.ToPoco()";

                if (t.IsGenericType && t.IsList() && t.GetGenericArguments()[0].IsProxyable())
                    return $"_{p.Name}.Select(x => x.ToPoco()).ToList()";

                if (t.IsArray && t.GetElementType().IsProxyable())
                    return $"_{p.Name}.Select(x => x.ToPoco()).ToArray()";

                return $"_{p.Name}";
            });

            proxySringBuilder.Append(string.Join(", ", constructorValues));

			proxySringBuilder.AppendLine(");");
            proxySringBuilder.AppendLine("}");

			string proxyPath = Path.Combine(Application.dataPath, "Proxy Generated", $"{type.Name}Proxy.cs");
			string proxyCode = proxySringBuilder.ToString();

			if (!Directory.Exists(Path.GetDirectoryName(proxyPath)))
				Directory.CreateDirectory(Path.GetDirectoryName(proxyPath));

			if (File.Exists(proxyPath) && File.ReadAllText(proxyPath) == proxySringBuilder.ToString())
				continue;

			File.WriteAllText(proxyPath, proxySringBuilder.ToString());

            AssetDatabase.Refresh();
        }
	}

    private static readonly Dictionary<Type, string> _typeAlias = new()
    {
        { typeof(bool), "bool" },
        { typeof(byte), "byte" },
        { typeof(char), "char" },
        { typeof(decimal), "decimal" },
        { typeof(double), "double" },
        { typeof(float), "float" },
        { typeof(int), "int" },
        { typeof(long), "long" },
        { typeof(sbyte), "sbyte" },
        { typeof(short), "short" },
        { typeof(string), "string" },
        { typeof(uint), "uint" },
        { typeof(ulong), "ulong" },
        { typeof(ushort), "ushort" },
        { typeof(void), "void" }
    };

    private static string GetSafetyTypeName(Type type)
    {
        if (_typeAlias.TryGetValue(type, out var alias))
            return alias;

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return $"{GetSafetyTypeName(Nullable.GetUnderlyingType(type))}?";

        if (type.IsGenericType)
        {
            string name = type.Name.Split('`')[0];
            string args = string.Join(", ", type.GetGenericArguments().Select(type =>
                type.IsProxyable() ? type.GetProxyName() : GetSafetyTypeName(type)));

            return $"{name}<{args}>";
        }

        if (type.IsArray)
        {
            Type element = type.GetElementType();
            string name = element.IsProxyable() ? element.GetProxyName() : GetSafetyTypeName(element);
            return $"{name}[]";
        }
        
        if (type.IsNested)
            return $"{GetSafetyTypeName(type.DeclaringType)}.{type.Name}";

        if (type.GetConstructors().Any(c => c.HasGenerateProxyAttribute()))
            return type.GetProxyName();

        return type.Name;
    }
    private static string GetProxyName(this Type type) => $"{type.Name}Proxy";
    private static bool IsProxyable(this Type type) => type.GetConstructors().Any(c => c.HasGenerateProxyAttribute());
    private static bool IsList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
    private static bool HasGenerateProxyAttribute(this ConstructorInfo constructorInfo) => constructorInfo.GetCustomAttribute<GenerateProxy>() != null;
}
