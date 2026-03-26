namespace UnityIceFebruary.AutoGeneration
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
        public static void SetConstructorTitle(this StringBuilder stringBuilder, Type classProxy, Type inheritType = null, string attribute = "")
        {
            if (!string.IsNullOrEmpty(attribute))
                stringBuilder.AppendLine($"[{attribute}]");

            stringBuilder.Append($"public class {classProxy.Name.ToProxyName()}");

            if (inheritType != null)
                stringBuilder.AppendLine($" : {(inheritType.IsProxyable() ? inheritType.Name.ToProxyName() : inheritType.FullName)}");
            else
                stringBuilder.AppendLine();
        }
        public static void SetFields(this StringBuilder stringBuilder, ParameterInfo[] parameters)
        {
            foreach (ParameterInfo parameter in parameters)
                stringBuilder.AppendLine(GetField(parameter));
        }
        public static void SetConstructor(this StringBuilder stringBuilder, Type classProxy, ParameterInfo[] parameters, Type returnType = null)
        {
            string classProxyName = classProxy.FullName;
            string returnTypeName = returnType != null ? returnType.FullName : classProxyName;

            IEnumerable<string> values = parameters.Select(parameter => GetProxyValue(parameter));

            stringBuilder.Append(returnTypeName == classProxyName ? $"    public {returnTypeName} ToPoco() => new(" : $"    public {returnTypeName} ToPoco() => new {classProxyName}(");
            stringBuilder.Append(string.Join(", ", values));
            stringBuilder.AppendLine(");");
        }
        public static void SetInterface(this StringBuilder stringBuilder, Type interfaceProxy)
        {
            stringBuilder.AppendLine($"public interface {interfaceProxy.Name.ToProxyName()}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"    {interfaceProxy.FullName} ToPoco();");
            stringBuilder.AppendLine("}");
        }
        public static string GetField(ParameterInfo parameter)
        {
            Type parameterType = parameter.ParameterType;

            string typeName = parameterType.GetSafetyTypeName();
            string stringAttribute = (parameterType.IsInterface || parameterType.IsAbstract) ? "[UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation]" : "[UnityEngine.SerializeField]";

            return $"    {stringAttribute} private {typeName} _{parameter.Name};";
        }
        public static string GetProxyValue(ParameterInfo parameter)
        {
            Type type = parameter.ParameterType;
            string parameterName = $"_{parameter.Name}";

            if (type.IsProxyable())
                return $"{parameterName}.ToPoco()";

            Type elementType = type.GetElementType();

            if (type.IsArray && elementType.IsProxyable())
                return $"System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select({parameterName} ?? new {elementType.GetSafetyTypeName()}[0], x => x.ToPoco()))";
            if (type.IsList() && type.GetGenericArguments()[0].IsProxyable())
                return $"System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select({parameterName} ?? new(), x => x.ToPoco()))";

            return parameterName;
        }
    }
}