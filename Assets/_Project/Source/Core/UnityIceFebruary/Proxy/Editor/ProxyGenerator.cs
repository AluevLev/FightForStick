namespace UnityIceFebruary.Proxy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using UnityEditor;
    using UnityEngine;
    using IceFebruary.Proxy;

    public static class ProxyGenerator
    {
        private static bool IsGenerate = true;

        [MenuItem("Tools/Generate all proxies")]
        public static void Generate()
        {
            if (!IsGenerate)
                return;

            Debug.Log($"Assemblies found: {AppDomain.CurrentDomain.GetAssemblies().Length}");

            IEnumerable<Type> assembiles = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes());

            IEnumerable<Type> interfaceProxies = assembiles.Where(type => type.IsInterfaceProxyable());
            IEnumerable<Type> classProxies = assembiles.Where(type => type.IsProxyableConstructors());

            foreach (Type interfaceProxy in interfaceProxies)
                GenerateInterfaceProxy(interfaceProxy);
            foreach (Type classProxy in classProxies)
                GenerateClassProxy(classProxy);

            AssetDatabase.Refresh();
        }
        private static void GenerateClassProxy(Type classProxy)
        {
            ConstructorInfo[] constructors = classProxy.GetConstructors();

            GenerateProxy generateInterfaceProxy = null;
            ConstructorInfo constructor = constructors.First(c => c.HasAttribute(out generateInterfaceProxy));

            Type interfaceType = generateInterfaceProxy?.InterfaceType;
            bool hasInterfaceType = interfaceType != null;

            ParameterInfo[] parameters = constructor.GetParameters();

            string proxyName = classProxy.GetProxyName();

            bool useGeneric = parameters.Any(parameterInfo => parameterInfo.ParameterType.IsGenericType);
            bool isListPresent = parameters.Any(parameterInfo => parameterInfo.ParameterType.IsGenericType && parameterInfo.ParameterType.GetGenericTypeDefinition() == typeof(List<>));
            bool isArrayPresent = parameters.Any(parameterInfo => parameterInfo.ParameterType.IsArray);
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
            proxySringBuilder.Append($"public class {proxyName}");

            if (hasInterfaceType)
                proxySringBuilder.AppendLine($" : {interfaceType.GetProxyName()}");
            else
                proxySringBuilder.AppendLine();

            proxySringBuilder.AppendLine("{");

            foreach (ParameterInfo parameter in parameters)
            {
                Type parameterType = parameter.ParameterType;

                string typeName = parameterType.IsInterfaceProxyable() ? parameterType.GetProxyName() : parameterType.GetSafetyTypeName();

                string initializer = parameterType.IsList() ? " = new()" : "";
                bool isInterface = parameterType.IsInterface || parameterType.IsAbstract;
                string attribute = isInterface ? "    [SerializeReference, InterfaceImplementation]" : "    [SerializeField]";

                proxySringBuilder.AppendLine($"{attribute} private {typeName} _{parameter.Name};");
            }

            proxySringBuilder.AppendLine("");

            proxySringBuilder.Append(hasInterfaceType ? $"    public {interfaceType.Name} ToPoco() => new {classProxy.Name}(" : $"    public {classProxy.Name} ToPoco() => new(");

            IEnumerable<string> constructorValues = parameters.Select(parameter =>
            {
                Type type = parameter.ParameterType;
                string parameterName = parameter.Name;

                if (type.IsProxyableConstructors() || type.IsInterfaceProxyable())
                    return $"_{parameterName}.ToPoco()";

                if (type.IsGenericType && type.IsList() && type.GetGenericArguments()[0].IsProxyableConstructors())
                    return $"_{parameterName}.Select(x => x.ToPoco()).ToList()";

                if (type.IsArray && type.GetElementType().IsProxyableConstructors())
                    return $"_{parameterName}.Select(x => x.ToPoco()).ToArray()";

                return $"_{parameterName}";
            });

            proxySringBuilder.Append(string.Join(", ", constructorValues));

            proxySringBuilder.AppendLine(");");
            proxySringBuilder.AppendLine("}");

            SaveProxy(proxyName, proxySringBuilder);
        }
        private static void GenerateInterfaceProxy(Type interfaceProxy)
        {
            string proxyName = interfaceProxy.GetProxyName();

            StringBuilder proxySringBuilder = new();

            proxySringBuilder.AppendLine("// AUTO-GENERATED. DO NOT EDIT.");
            proxySringBuilder.AppendLine($"public interface {proxyName}");
            proxySringBuilder.AppendLine("{");
            proxySringBuilder.AppendLine($"    {interfaceProxy.Name} ToPoco();");
            proxySringBuilder.AppendLine("}");

            SaveProxy(proxyName, proxySringBuilder);
        }
        private static void SaveProxy(string proxyName, StringBuilder proxyStringBuilder)
        {
            string proxyPath = Path.Combine(Application.dataPath, "ProxyGenerated", $"{proxyName}.cs");
            string proxyCode = proxyStringBuilder.ToString();

            if (!Directory.Exists(Path.GetDirectoryName(proxyPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(proxyPath));

            if (File.Exists(proxyPath) && File.ReadAllText(proxyPath) == proxyCode)
                return;

            File.WriteAllText(proxyPath, proxyCode);
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

        private static string GetSafetyTypeName(this Type type)
        {
            if (_typeAlias.TryGetValue(type, out string alias))
                return alias;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return $"{Nullable.GetUnderlyingType(type).GetSafetyTypeName()}?";

            if (type.IsGenericType)
            {
                string name = type.Name.Split('`')[0];
                string args = string.Join(", ", type.GetGenericArguments().Select(type => type.IsProxyableConstructors() ? type.GetProxyName() : GetSafetyTypeName(type)));

                return $"{name}<{args}>";
            }

            if (type.IsArray)
            {
                Type element = type.GetElementType();
                string name = element.IsProxyableConstructors() ? element.GetProxyName() : GetSafetyTypeName(element);
                return $"{name}[]";
            }

            if (type.IsNested)
                return $"{type.DeclaringType.GetSafetyTypeName()}.{type.Name}";

            if (type.IsProxyableConstructors())
                return type.GetProxyName();

            return type.Name;
        }
        private static string GetProxyName(this Type type) => $"{type.Name}Proxy";
        private static bool IsProxyableConstructors(this Type type) => type.GetConstructors().Any(c => c.HasAttribute(out GenerateProxy _) || c.HasAttribute(out GenerateInterfaceProxy _));
        private static bool IsInterfaceProxyable(this Type type) => type.IsInterface && type.HasAttribute(out GenerateInterfaceProxy _);
        private static bool IsList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        private static bool HasAttribute<TSource, TAttribute>(this TSource constructorInfo, out TAttribute generateProxy)
            where TAttribute : Attribute
            where TSource : MemberInfo
        {
            generateProxy = constructorInfo?.GetCustomAttribute<TAttribute>();
            return generateProxy != null;
        }
    }
}
