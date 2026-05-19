namespace UnityIceFebruary.AutoGenerator
{
    using IceFebruary.Proxy;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Collections.Generic;

    public static class ProxyCodeBuilder
    {
        public static string GetInterfaceProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"public interface {type.GetProxyName()}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\tpublic {type.FullName} ToPoco();");
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
        public static string GetFieldProxyCode(Type type, FieldProxy fieldProxy)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("[System.Serializable]");
            stringBuilder.Append($"public class {type.GetProxyName()}");

            Type fieldProxyInterface = fieldProxy.InterfaceType;

            if (fieldProxyInterface != null)
            {
                stringBuilder.Append(" : ");

                if (fieldProxyInterface.HasAttribute<InterfaceProxy>())
                    stringBuilder.AppendLine(fieldProxyInterface.GetProxyName());
                else
                    stringBuilder.AppendLine(fieldProxyInterface.FullName);
            }

            stringBuilder.SetAverageBody(type);

            return stringBuilder.ToString();
        }
        public static string GetScriptableObjectProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"[UnityEngine.CreateAssetMenu(fileName = \"{type.Name}Proxy\", menuName = \"Proxy/{type.Name}\")]");
            stringBuilder.AppendLine($"public class {type.GetProxyName()} : UnityEngine.ScriptableObject");
            stringBuilder.SetAverageBody(type);

            return stringBuilder.ToString();
        }
        public static string GetProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"public class {type.GetProxyName()} : UnityEngine.MonoBehaviour");
            stringBuilder.SetAverageBody(type);

            return stringBuilder.ToString();
        }
        public static string GetUnityProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            Type original = type.BaseType.GetGenericArguments()[0];
            string originalName = original.FullName;

            stringBuilder.AppendLine("[System.Serializable]");
            stringBuilder.AppendLine($"public class {type.GetProxyName()}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"\t[UnityEngine.SerializeField] private {originalName} _component;");
            stringBuilder.AppendLine($"\tpublic {originalName} ToPoco() => _component;");
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
        private static void SetAverageBody(this StringBuilder stringBuilder, Type type)
        {
            stringBuilder.AppendLine("{");

            ConstructorInfo constructor = type.GetConstructors().First();
            ParameterInfo[] parameters = constructor.GetParameters();
            List<string> parametersNames = new();

            foreach (ParameterInfo parameterInfo in parameters)
            {
                Type parameterType = parameterInfo.ParameterType;
                string parameterName = parameterType.FullName;

                if (parameterType.IsInterface)
                    stringBuilder.Append("\t[UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation]");
                else
                    stringBuilder.Append("\t[UnityEngine.SerializeField]");

                stringBuilder.Append(" private ");

                bool isProxyable = parameterType.IsProxyable();
                bool isProxyableArray = parameterType.IsProxyableArray();
                bool isProxyableList = parameterType.IsProxyableList();

                if (isProxyable)
                    stringBuilder.Append(parameterType.GetProxyName());

                else if (isProxyableArray)
                {
                    Type elementType = parameterType.GetElementType();
                    stringBuilder.Append($"{elementType.GetProxyName()}[]");
                }

                else if (isProxyableList)
                {
                    Type elementType = parameterType.GetGenericArguments()[0];
                    stringBuilder.Append($"System.Collections.Generic.List<{elementType.GetProxyName()}>");
                }

                else
                    stringBuilder.Append(parameterName);

                string parameterFieldName = $"_{parameterInfo.Name}";

                stringBuilder.AppendLine($" {parameterFieldName};");

                if (isProxyable)
                    parametersNames.Add($"{parameterFieldName}.ToPoco()");
                else if (isProxyableArray)
                    parametersNames.Add($"IceFebruary.Collections.GenericArraysExtensions.ToStructArray(System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select({parameterFieldName} ?? new {parameterType.GetElementType().GetProxyName()}[0], element => element?.ToPoco())))");
                else if (isProxyableList)
                    parametersNames.Add($"System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select({parameterFieldName} ?? new(), element => element?.ToPoco()))");
                else
                    parametersNames.Add(parameterFieldName);
            }

            stringBuilder.Append($"\tpublic ");

            string typeName = type.FullName;

            if (type.HasAttribute<FieldProxy>())
            {
                FieldProxy attribute = type.GetAttribute<FieldProxy>();
                Type interfaceProxy = attribute.InterfaceType;

                if (interfaceProxy == null)
                    stringBuilder.Append(typeName);
                else
                    stringBuilder.Append(interfaceProxy.FullName);
            }

            else
                stringBuilder.Append(typeName);

            stringBuilder.Append($" ToPoco() => new {typeName}(");
            stringBuilder.Append(string.Join(", ", parametersNames));
            stringBuilder.AppendLine(");");
            stringBuilder.AppendLine("}");
        }
        private static bool IsProxyableList(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>) && type.GetGenericArguments()[0].IsProxyable();
        private static bool IsProxyableArray(this Type type) => type.IsArray && type.GetElementType().IsProxyable();
    }
}
