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
            stringBuilder.Append($"public sealed class {type.GetProxyName()}");

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
            stringBuilder.AppendLine($"public sealed class {type.GetProxyName()} : UnityEngine.ScriptableObject");
            stringBuilder.SetAverageBody(type);

            return stringBuilder.ToString();
        }
        public static string GetProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"public sealed class {type.GetProxyName()} : UnityEngine.MonoBehaviour");
            stringBuilder.SetAverageBody(type);

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

                string parameterFieldName = $"_{parameterInfo.Name}";

                if (parameterType.IsProxyable())
                {
                    stringBuilder.Append(parameterType.GetProxyName());
                    parametersNames.Add($"{parameterFieldName}.ToPoco()");
                }
                    
                else if (parameterType.IsProxyableArray(out Type arrayElementType))
                {
                    string elementTypeName = arrayElementType.GetProxyName();

                    stringBuilder.Append($"{elementTypeName}[]");
                    parametersNames.Add($"System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select({parameterFieldName} ?? new {elementTypeName}[0], element => element.ToPoco()))");
                }
                    
                else if (parameterType.IsProxyableList(out Type listElementType))
                {
                    stringBuilder.Append($"System.Collections.Generic.List<{listElementType.GetProxyName()}>");
                    parametersNames.Add($"System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select({parameterFieldName} ?? new(), element => element.ToPoco()))");
                }

                else
                {
                    stringBuilder.Append(parameterName);
                    parametersNames.Add(parameterFieldName);
                }

                stringBuilder.AppendLine($" {parameterFieldName};");
            }

            stringBuilder.Append($"\tpublic ");

            string typeName = type.FullName;

            if (type.HasAttribute<FieldProxy>())
            {
                Type interfaceProxy = type.GetAttribute<FieldProxy>().InterfaceType;

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
    }
}
