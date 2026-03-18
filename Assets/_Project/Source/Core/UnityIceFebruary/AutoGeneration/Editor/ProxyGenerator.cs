namespace UnityIceFebruary.AutoGeneration
{
    using IceFebruary.Proxy;
    using System;
    using System.Collections.Generic;
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
            IEnumerable<Type> allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes());

            foreach (Type type in allTypes)
                GenerateProxy(type);

            AssetDatabase.Refresh();

            Debug.Log("Proxy Generation Complete!");
        }
        private static void GenerateProxy(Type type)
        {
            StringBuilder stringBuilder = new();

            ProxyCodeBuilder.SetWarning(stringBuilder);

            if (type.HasAttribute(out GenerateProxy _))
                ProcessGenerateProxy(type, stringBuilder);
            else if (type.HasAttribute(out GenerateInterfaceProxy _))
                ProcessGenerateInterfaceProxy(type, stringBuilder);
            else if (type.HasAttribute(out GenerateScriptableObjectProxy _))
                ProcessGenerateScriptableObjectProxy(type, stringBuilder);
            else
                return;

            ProxySaver.SaveProxy(stringBuilder, type);
        }
        private static void ProcessGenerateProxy(Type classProxy, StringBuilder stringBuilder)
        {
            GenerateProxy attribute = null;
            ConstructorInfo constructor = classProxy.GetConstructors().First(c => c.HasAttribute(out attribute));
            ParameterInfo[] parameters = constructor.GetParameters();
            Type interfaceType = attribute.InterfaceType;

            stringBuilder.SetUsings(parameters);

            stringBuilder.SetTitle(classProxy, interfaceType, ProxyAttribute.Serializable);

            stringBuilder.SetStartBrace();

            stringBuilder.SetFields(parameters);

            stringBuilder.SetConstructor(classProxy, parameters, interfaceType);

            stringBuilder.SetEndBrace();
        }
        private static void ProcessGenerateScriptableObjectProxy(Type scriptableObjectProxy, StringBuilder stringBuilder)
        {
            GenerateScriptableObjectProxy attribute = null;
            ConstructorInfo constructor = scriptableObjectProxy.GetConstructors().First(c => c.HasAttribute(out attribute));
            ParameterInfo[] parameters = constructor.GetParameters();

            stringBuilder.SetUsings(parameters);

            stringBuilder.SetTitle(scriptableObjectProxy, typeof(ScriptableObject), ProxyAttribute.GetProxyAssetMenuAttribute(scriptableObjectProxy));

            stringBuilder.SetStartBrace();

            stringBuilder.SetFields(parameters);

            stringBuilder.SetConstructor(scriptableObjectProxy, parameters);

            stringBuilder.SetEndBrace();
        }
        private static void ProcessGenerateInterfaceProxy(Type interfaceProxy, StringBuilder stringBuilder) => ProxyCodeBuilder.SetInterface(stringBuilder, interfaceProxy);
    }
}
