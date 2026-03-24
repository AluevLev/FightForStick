namespace UnityIceFebruary.AutoGeneration.Proxy
{
    using IceFebruary.Proxy;
    using System;

    public static class ProxyAttribute
    {
        public static string GetProxyAssetMenuAttribute(Type type) => $"UnityEngine.CreateAssetMenu(fileName = \"{type.Name.ToProxyName()}\", menuName = \"Proxy/{type.Name}\")";
        public static readonly string Serializable = "System.Serializable";
    }
}
