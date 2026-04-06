namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Interface)]
    public sealed class InterfaceProxy : Attribute, IProxyInterface
    {

    }
}
