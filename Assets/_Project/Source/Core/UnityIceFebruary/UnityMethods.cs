namespace UnityIceFebruary
{
    using IceFebruary;
    using System;
    using System.Runtime.CompilerServices;
    using UnityIceFebruary.Components;

    using UnityObject = UnityEngine.Object;

    public static class UnityMethods
    {
        private static readonly ConditionalWeakTable<UnityObject, IBaseEntity> _objects = new();
        public static TConversion Upsert<T, TConversion>(T unityObject) where T : UnityObject where TConversion : IBaseEntity => unityObject != null && UnityMatchObject.FabricAliases.TryGetValue(unityObject.GetType(), out Func<UnityObject, IBaseEntity> factory) ? (TConversion)_objects.GetValue(unityObject, obj => factory((T)obj)) : default;
        public static void Remove<T>(IUnityAnalog<T> analog) where T : UnityObject
        {
            if (analog != null)
                _objects.Remove(analog.Original);
        }
    }
}
