namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Struct)]
    public sealed class Proxy : Attribute, IProxyConstructor
    {

    }
}
