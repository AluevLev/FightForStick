namespace UnityIceFebruary.AutoGeneration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using UnityEditor;

    public static class ProxyCodeBuilder
    {
        public static void SetWarning(this StringBuilder stringBuilder) => stringBuilder.AppendLine("// AUTO-GENERATED. DO NOT EDIT.");
        public static void SetStartBrace(this StringBuilder stringBuilder) => stringBuilder.AppendLine("{");
        public static void SetEndBrace(this StringBuilder stringBuilder) => stringBuilder.AppendLine("}");
        public static void SetUsings(this StringBuilder stringBuilder, ParameterInfo[] parameters)
        {
            stringBuilder.AppendLine("using UnityEngine;");

            if (parameters.Any(parameter => parameter.ParameterType.IsGenericType))
                stringBuilder.AppendLine("using System.Collections.Generic;");

            if (parameters.Any(parameter => parameter.ParameterType.IsArray || parameter.ParameterType.IsList()))
                stringBuilder.AppendLine("using System.Linq;");

            stringBuilder.AppendLine();
        }
        public static void SetTitle(this StringBuilder stringBuilder, Type classProxy, Type inheritType = null, string attribute = "")
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