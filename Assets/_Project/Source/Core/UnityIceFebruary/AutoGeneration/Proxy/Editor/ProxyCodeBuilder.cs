namespace UnityIceFebruary.AutoGeneration.Proxy
{
    using IceFebruary.Proxy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using UnityEditor;

    public static class ProxyCodeBuilder
    {
        public static void SetWarning(this StringBuilder stringBuilder) => stringBuilder.AppendLine("// AUTO-GENERATED. DO NOT EDIT.");
        public static void SetStartBrace(this StringBuilder stringBuilder, int tabs = 0) => stringBuilder.AppendLine($"{GetTabs(tabs)}{{"); 
        public static void SetEndBrace(this StringBuilder stringBuilder, int tabs = 0) => stringBuilder.AppendLine($"{GetTabs(tabs)}}}");
        public static string GetTabs(int tabs) => tabs > 0 ? new('\t', tabs) : string.Empty;
        public static void SetUsingsWithParameters(this StringBuilder stringBuilder, ParameterInfo[] parameters)
        {
            HashSet<string> namespaces = new()
            {
                "System",
                "UnityEngine"
            };

            bool needLinq = false;

            foreach (ParameterInfo parameter in parameters)
            {
                Type t = parameter.ParameterType;
                GetUsing(t, namespaces);
                needLinq = t.IsArray && t.GetElementType().IsProxyable() || t.IsList() && t.GetGenericArguments()[0].IsProxyable();
            }

            if (needLinq)
                namespaces.Add("System.Linq");

            foreach (string @namespace in namespaces.OrderBy(x => x))
                stringBuilder.AppendLine($"using {@namespace};");
        }
        public static void GetUsing(Type type, HashSet<string> namespaces)
        {
            if (type == null)
                return;

            string @namespace = type.Namespace;

            if (!string.IsNullOrEmpty(@namespace))
                namespaces.Add(@namespace);
            if (type.IsGenericType)
                foreach (Type element in type.GetGenericArguments())
                    GetUsing(element, namespaces);
            if (type.IsArray)
                GetUsing(type.GetElementType(), namespaces);
            if (type.IsNested && type.DeclaringType != null)
                GetUsing(type.DeclaringType, namespaces);
        }
        public static void SetConstructorTitle(this StringBuilder stringBuilder, Type classProxy, Type inheritType = null, string attribute = "")
        {
            if (!string.IsNullOrEmpty(attribute))
                stringBuilder.AppendLine($"[{attribute}]");

            stringBuilder.Append($"public class {classProxy.GetProxyName()}");

            if (inheritType != null)
                stringBuilder.AppendLine($" : {(inheritType.IsProxyable() ? inheritType.GetProxyName() : inheritType.Name)}");
        }
        public static void SetFields(this StringBuilder stringBuilder, ParameterInfo[] parameters)
        {
            foreach (ParameterInfo parameter in parameters)
                stringBuilder.AppendLine(GetField(parameter));
        }
        public static void SetConstructor(this StringBuilder stringBuilder, Type classProxy, ParameterInfo[] parameters, Type returnType = null)
        {
            string classProxyName = classProxy.Name;
            string returnTypeName = returnType != null ? returnType.Name : classProxyName;

            IEnumerable<string> values = parameters.Select(parameter => GetProxyValue(parameter));

            stringBuilder.Append($"    public {returnTypeName} ToPoco() => new {classProxyName}(");
            stringBuilder.Append(string.Join(", ", values));
            stringBuilder.AppendLine(");");
        }
        public static void SetInterface(this StringBuilder stringBuilder, Type interfaceProxy)
        {
            stringBuilder.AppendLine($"public interface {interfaceProxy.GetProxyName()}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"    {interfaceProxy.Name} ToPoco();");
            stringBuilder.AppendLine("}");
        }
        public static string GetField(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;

            string typeName = parameterType.GetSafetyTypeName();
            string stringAttribute = (parameterType.IsInterface || parameterType.IsAbstract) ? "[SerializeReference, InterfaceImplementation]" : "[SerializeField]";

            return $"    {stringAttribute} private {typeName} _{parameter.Name};";
        }
        public static string GetProxyValue(ParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            string parameterName = parameter.Name;

            if (type.IsProxyable())
                return $"_{parameterName}.ToPoco()";
            if (type.IsArray && type.GetElementType().IsProxyable())
                return $"_{parameterName}.Select(x => x.ToPoco()).ToArray()";
            if (type.IsList() && type.GetGenericArguments()[0].IsProxyable())
                return $"_{parameterName}.Select(x => x.ToPoco()).ToList()";
            return $"_{parameterName}";
        }
    }
}