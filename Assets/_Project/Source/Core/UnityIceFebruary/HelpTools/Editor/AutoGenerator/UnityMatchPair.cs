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
        public static string GetFabricAliasesPair(UnityMatchPair pair)
        {
            string unityTypeName = pair.UnityType.FullName;
            string unityAnalogTypeName = pair.UnityAnalogType.FullName;

            return $"        {{ typeof({unityTypeName}), obj => new {unityAnalogTypeName}(({unityTypeName})obj) }}";
        }
    }
}
