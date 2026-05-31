namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;
    using System;

    using UnityObject = UnityEngine.Object;

    public static class UnityMethods
    {
        public static Type GetUnityType<T>() where T : class, IBaseEntity => UnityMatchObject.UnityAnalogs.TryGetValue(typeof(T), out Type type) ? type : null;
        public static IBaseEntity Upsert<T>(T unityObject) where T : UnityObject => (unityObject != null && UnityMatchObject.FabricAliases.TryGetValue(unityObject.GetType(), out Func<UnityObject, IBaseEntity> factory)) ? UnityHierarchyCache.Upsert(unityObject, factory) : null;
        public static void Remove<T>(IUnityAnalog<T> analog) where T : UnityObject
        {
            if (analog != null)
                UnityHierarchyCache.Remove(analog.Original);
        }
    }
}
