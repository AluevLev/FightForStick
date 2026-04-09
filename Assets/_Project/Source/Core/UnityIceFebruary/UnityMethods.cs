namespace UnityIceFebruary
{
    using UnityEngine;
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
        public static IGameObject Upsert(GameObject gameObject)
        {
            if (gameObject == null)
                return null;

            return UnityHierarchyCache.Upsert(gameObject, g => new UnityGameObject(g));
        }
        public static IUnityAnalog Upsert(Component component)
        {
            if (component == null)
                return null;

            if (!UnityMatchComponent.FabricAliases.TryGetValue(component.GetType(), out Func<Component, IUnityAnalog> fabric))
                return null;

            return UnityHierarchyCache.Upsert(component, fabric);
        }
        public static void Remove(UnityGameObject gameObject)
        {
            if (gameObject == null)
                return;

            UnityHierarchyCache.Remove(gameObject.GameObject);
        }
        public static void Remove(IUnityAnalog analog)
        {
            if (analog == null)
                return;

            UnityHierarchyCache.Remove(analog.Original as Component);
        }
    }
}
