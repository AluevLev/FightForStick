namespace UnityIceFebruary.AutoGeneration
{
    using System;

    public static class ProxyAttribute
    {
        public static string GetProxyAssetMenuAttribute(Type type) => $"CreateAssetMenu(fileName = \"{type.GetProxyName()}\", menuName = \"Proxy/{type.Name}\")";
        public static readonly string Serializable = "System.Serializable";
    }
}
