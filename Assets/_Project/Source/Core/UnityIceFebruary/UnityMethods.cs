namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;
    using System;

    using UnityObject = UnityEngine.Object;

    public static class UnityMethods
    {
        public static Type GetUnityType<T>() where T : class, IBaseEntity
        {
            if (!UnityMatchObject.UnityAnalogs.TryGetValue(typeof(T), out Type type))
                return null;

            return type;
        }
        public static IBaseEntity Upsert<T>(T unityObject) where T : UnityObject
        {
            if (unityObject == null || !UnityMatchObject.FabricAliases.TryGetValue(unityObject.GetType(), out Func<UnityObject, IBaseEntity> factory))
                return null;

            return UnityHierarchyCache.Upsert(unityObject, factory);
        }
        public static void Remove<T>(IUnityAnalog<T> analog) where T : UnityObject
        {
            if (analog == null)
                return;

            UnityHierarchyCache.Remove(analog.Original);
        }
    }
}
