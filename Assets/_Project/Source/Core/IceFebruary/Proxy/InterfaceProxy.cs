namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Interface)]
    public class InterfaceProxy : Attribute, IProxyInterface
    {

    }
}
