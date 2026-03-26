namespace UnityIceFebruary.AutoGeneration
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class UnityAnalog : Attribute
    {
        public Type Analog { get; private init; }
        public UnityAnalog(Type analog)
        {
            Analog = analog;
        }
    }
}
