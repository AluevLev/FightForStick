namespace IceFebruary.Proxy
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Class)]
    public sealed class Proxy : GeneratorAttribute { }
}
