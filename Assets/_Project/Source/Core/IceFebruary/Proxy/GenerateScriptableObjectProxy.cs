namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Struct)]
    public class GenerateScriptableObjectProxy : Attribute { }
}