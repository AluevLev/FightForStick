namespace February.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor)]
    public class GenerateProxy : Attribute
    {
        public Type InterfaceType { get; }
        public GenerateProxy(Type interfaceType = null) => InterfaceType = interfaceType;
    }
}
