namespace UnityIceFebruary
{
    using UnityEngine;
    using UnityIceFebruary.Components;
    using System;
    using System.Runtime.CompilerServices;
    using IceFebruary;

    public static class UnityHierarchyCache
    {
        private static readonly ConditionalWeakTable<Component, IUnityAnalog> _components = new();
        private static readonly ConditionalWeakTable<GameObject, IGameObject> _gameObjects = new();
        public static IGameObject Upsert(GameObject original, Func<GameObject, IGameObject> factory)
        {
            if (original == null)
                return null;
            return _gameObjects.GetValue(original, c => factory(c));
        }
        public static T Upsert<T>(Component original, Func<Component, T> fabric) where T : IUnityAnalog
        {
            if (original == null)
                return default;
            return (T)_components.GetValue(original, c => fabric(c));
        }
        public static void Remove(GameObject original) => _gameObjects.Remove(original);
        public static void Remove(Component original) => _components.Remove(original);
    }
}
