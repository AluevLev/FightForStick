namespace UnityIceFebruary.AutoGeneration.Match
{
    using System;
    using UnityEngine;

    [AttributeUsage(AttributeTargets.Class)]
    public class UnityAnalog : Attribute
    {
        public Component Analog { get; private init; }
        public UnityAnalog(Component analog)
        {
            Analog = analog;
        }
    }
}
