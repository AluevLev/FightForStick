namespace UnityIceFebruary.AutoGeneration.Match
{
    using System;

    public readonly struct Match
    {
        public Type Type { get; private init; }
        public UnityAnalog Analog { get; private init; }
        public string TypeName { get; private init; }
        public string AnalogName { get; private init; }
        public Match(Type type, UnityAnalog analog)
        {
            Type = type;
            Analog = analog;

            TypeName = Type.Name;
            AnalogName = Analog.Analog.Name;
        }
    }
}
