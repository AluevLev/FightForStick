namespace UnityIceFebruary
{
    using System;
    using System.Runtime.CompilerServices;
    using IceFebruary;

    public static class UnityHierarchyCache
    {
        private static readonly ConditionalWeakTable<UnityEngine.Object, IBaseEntity> _objects = new();
        public static IBaseEntity Upsert<T>(T unityObject, Func<T, IBaseEntity> factory) where T : UnityEngine.Object
        {
            if (unityObject == null)
                return null;

            return _objects.GetValue(unityObject, obj => factory((T)obj));
        }
        public static void Remove<T>(T unityObject) where T : UnityEngine.Object => _objects.Remove(unityObject);
    }
}
