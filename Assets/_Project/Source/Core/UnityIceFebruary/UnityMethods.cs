namespace UnityIceFebruary
{
    using UnityEngine;
    using IceFebruary;
    using System;

    public static class UnityMethods
    {
        public static Type GetUnityType<T>() where T : class, IComponent
        {
            if (!UnityComponentConverter.UnityAnalogs.TryGetValue(typeof(T), out Type type))
                return null;

            return type;
        }
        public static IGameObject Create(GameObject gameObject)
        {
            if (gameObject == null)
                return null;

            return HierarchyCache.Upsert(gameObject, g => new UnityGameObject(g));
        }
        public static IComponent Create(Component component)
        {
            if (component == null)
                return null;
            if (!UnityComponentConverter.FabricAliases.TryGetValue(component.GetType(), out Func<Component, IComponent> fabric))
                return null;

            return HierarchyCache.Upsert(component, fabric);
        }
    }

}
