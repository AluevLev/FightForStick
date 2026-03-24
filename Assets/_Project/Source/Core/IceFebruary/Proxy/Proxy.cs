namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor)]
    public class Proxy : Attribute, IProxyConstructor
    {
        public Type InterfaceType { get; private init; }
        public Proxy(Type interfaceType = null)
        {
            InterfaceType = interfaceType;
        }
    }
}
