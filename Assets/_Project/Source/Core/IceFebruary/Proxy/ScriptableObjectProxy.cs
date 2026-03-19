namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Struct)]
    public class ScriptableObjectProxy : Attribute, IProxyConstructor
    {

    }
}