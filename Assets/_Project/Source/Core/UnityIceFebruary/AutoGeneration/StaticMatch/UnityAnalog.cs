namespace UnityIceFebruary.AutoGeneration
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UnityAnalog : Attribute
    {
        public Type Analog { get; private init; }
        public UnityAnalog(Type analog)
        {
            Analog = analog;
        }
    }
}
