namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;
    using System;

    public static class UnityMethods
    {
        public static Type GetUnityType<T>() where T : class
        {
            if (!UnityMatchComponent.UnityAnalogs.TryGetValue(typeof(T), out Type type))
                return null;

            return type;
        }
        public static IBaseEntity Upsert<T>(T unityObject) where T : UnityEngine.Object
        {
            if (unityObject == null || !UnityMatchComponent.FabricAliases.TryGetValue(unityObject.GetType(), out Func<UnityEngine.Object, IBaseEntity> factory))
                return null;

            return UnityHierarchyCache.Upsert(unityObject, factory);
        }
        public static void Remove<T>(IUnityAnalog<T> analog) where T : UnityEngine.Object
        {
            if (analog == null)
                return;

            UnityHierarchyCache.Remove(analog.Original);
        }
    }
}
