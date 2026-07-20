namespace UnityIceFebruary.HelpTools.AutoGenerator
{
    using IceFebruary.Proxy;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Collections.Generic;
    using UnityIceFebruary.HelpTools.Debuggers;

    public static class ProxyCodeBuilder
    {
        public static string GetInterfaceProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"public interface {type.GetProxyName()}");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine($"    public {type.FullName} ToPoco();");
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }
        public static string GetFieldProxyCode(Type type, FieldProxy fieldProxy)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine("[System.Serializable]");
            stringBuilder.Append($"public sealed class {type.GetProxyName()}");

            Type fieldProxyInterface = fieldProxy.InterfaceType;
            bool fieldProxyInterfaceExists = fieldProxyInterface == null;

            if (fieldProxyInterfaceExists && !fieldProxyInterface.HasAttribute<InterfaceProxy>())
            {
                stringBuilder.AppendLine($" {{ }} //{ProxyGenerator.TroubleMark}");

                ProxyGeneratorDebugger.WarnAboutUnproxyableObject();

                return stringBuilder.ToString();
            }

            stringBuilder.AppendLine(fieldProxyInterfaceExists ? string.Empty : $" : {fieldProxyInterface.GetProxyName()}");
            stringBuilder.SetAverageBody(type, fieldProxy.InterfaceType);

            return stringBuilder.ToString();
        }
        public static string GetScriptableObjectProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"[UnityEngine.CreateAssetMenu(fileName = \"{type.Name}\", menuName = \"Proxy/{type.Name}\")]");
            stringBuilder.AppendLine($"public sealed class {type.GetProxyName()} : UnityEngine.ScriptableObject");
            stringBuilder.SetAverageBody(type);

            return stringBuilder.ToString();
        }
        public static string GetProxyCode(Type type)
        {
            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"public sealed class {type.GetProxyName()} : UnityIceFebruary.UnityInstantiateInfo<{type.FullName}>");
            stringBuilder.SetAverageBody(type, null, "override");

            return stringBuilder.ToString();
        }
        private static void SetAverageBody(this StringBuilder stringBuilder, Type type, Type toPocoType = null, string toPocoAdditionalKeys = null)
        {
            stringBuilder.AppendLine("{");

            ParameterInfo[] parameters = type.GetConstructors().First().GetParameters();
            List<string> parametersNames = new();

            foreach (ParameterInfo parameterInfo in parameters)
            {
                Type parameterType = parameterInfo.ParameterType;
                string parameterName = parameterType.FullName;

                stringBuilder.Append("    [UnityEngine.");
                stringBuilder.Append(parameterType.IsInterface ? "SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation" : "SerializeField");
                stringBuilder.Append("] private ");

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

            stringBuilder.Append($"    public ");

            string typeName = type.FullName;

            if (!string.IsNullOrWhiteSpace(toPocoAdditionalKeys))
                stringBuilder.Append($"{toPocoAdditionalKeys} ");

            stringBuilder.Append(toPocoType == null ? typeName : toPocoType.FullName);
            stringBuilder.Append($" ToPoco() => new {typeName}({string.Join(", ", parametersNames)}");
            stringBuilder.AppendLine(");");
            stringBuilder.AppendLine("}");
        }
    }
}
