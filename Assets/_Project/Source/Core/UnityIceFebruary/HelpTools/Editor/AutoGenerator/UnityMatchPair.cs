namespace UnityIceFebruary.HelpTools.AutoGenerator
{
    using System;

    public readonly struct UnityMatchPair
    {
        public Type UnityAnalogType { get; private init; }
        public Type UnityType { get; private init; }
        public UnityMatchPair(Type unityAnalogType, Type unityType)
        {
            UnityAnalogType = unityAnalogType;
            UnityType = unityType;
        }
    }
}
