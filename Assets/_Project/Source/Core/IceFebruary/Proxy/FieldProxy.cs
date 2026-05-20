namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor)]
    public sealed class FieldProxy : GeneratorAttribute
    {
        public Type InterfaceType { get; private init; }
        public FieldProxy(Type interfaceType = null)
        {
            InterfaceType = interfaceType;
        }
    }
}
