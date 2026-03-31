namespace UnityIceFebruary
{
    using UnityEngine;
    using IceFebruary;
    using UnityIceFebruary.Components;
    using System;

    public static class UnityMethods
    {
        public static Type GetUnityType<T>() where T : class, IComponent
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
        public static IComponent Upsert(Component component)
        {
            if (component == null)
                return null;

            if (!UnityMatchComponent.FabricAliases.TryGetValue(component.GetType(), out Func<Component, IComponent> fabric))
                return null;

            return UnityHierarchyCache.Upsert(component, fabric);
        }
        public static void Remove(IGameObject gameObject)
        {
            if (gameObject == null)
                return;

            if (gameObject is not UnityGameObject unityGameObject)
                return;

            UnityHierarchyCache.Remove(unityGameObject.GameObject);
        }
        public static void Remove(IComponent component)
        {
            if (component == null)
                return;

            if (component is not IUnityAnalog analog)
                return;

            UnityHierarchyCache.Remove(analog.Original as Component);
        }
    }
}
