namespace UnityIceFebruary.AutoGeneration
{
    using IceFebruary.Proxy;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using UnityEditor;
    using UnityEngine;

    public static class ProxyGenerator
    {
        public static void Generate(IEnumerable<Type> allTypes)
        {
            foreach (Type type in allTypes)
                GenerateProxy(type);

            AssetDatabase.Refresh();

            Debug.Log("Proxy Generation Complete!");
        }
        private static void GenerateProxy(Type type)
        {
            if (!type.IsProxyable())
                return;

            StringBuilder stringBuilder = new();

            stringBuilder.SetWarning();

            if (type.HasAttributeInConstructor(out IProxyConstructor attribute))
            {
                ProxyConstructorData? data = type.GetProxyConstructorData(attribute);

                if (!data.HasValue)
                    return;

                ProcessConstructorProxy(data.Value, stringBuilder);
            }

            if (type.HasAttribute(out IProxyInterface _))
            {
                ProcessGenerateInterfaceProxy(type, stringBuilder);
            }

            CSSaver.SaveProxy(stringBuilder, type);
        }
        private static void ProcessConstructorProxy(ProxyConstructorData data, StringBuilder stringBuilder)
        {
            stringBuilder.SetConstructorTitle(data.ClassProxy, data.InheritProxy, data.Attribute);

            stringBuilder.SetStartBrace();

            stringBuilder.SetFields(data.Parameters);

            stringBuilder.SetConstructor(data.ClassProxy, data.Parameters, data.ReturnType);

            stringBuilder.SetEndBrace();
        }
        public static ProxyConstructorData? GetProxyConstructorData(this Type type, IProxyConstructor attribute = null)
        {
            if (attribute == null && !type.HasAttributeInConstructor(out attribute))
                return null;

            if (attribute is Proxy proxy)
            {
                Type interfaceType = proxy.InterfaceType;
                return new(type, interfaceType, interfaceType, ProxyAttribute.Serializable);
            }

            if (attribute is ScriptableObjectProxy)
            {
                return new(type, typeof(ScriptableObject), type, ProxyAttribute.GetProxyAssetMenuAttribute(type));
            }

            return null;
        }
        private static void ProcessGenerateInterfaceProxy(Type interfaceProxy, StringBuilder stringBuilder) => ProxyCodeBuilder.SetInterface(stringBuilder, interfaceProxy);
    }
}
