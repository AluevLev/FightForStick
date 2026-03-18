namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor)]
    public class GenerateProxy : Attribute, IProxyConstructor
    {
        public Type InterfaceType { get; }
        public GenerateProxy(Type interfaceType = null) => InterfaceType = interfaceType;
    }
}
