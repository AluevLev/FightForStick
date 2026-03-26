namespace UnityIceFebruary
{
    using UnityEngine;
    using System;
    using System.Runtime.CompilerServices;
    using IceFebruary;

    public static class UnityHierarchyCache
    {
        private static readonly ConditionalWeakTable<Component, IComponent> _components = new();
        private static readonly ConditionalWeakTable<GameObject, IGameObject> _gameObjects = new();
        public static IGameObject Upsert(GameObject original, Func<GameObject, IGameObject> factory) => _gameObjects.GetValue(original, c => factory(c));
        public static T Upsert<T>(Component original, Func<Component, T> fabric) where T : IComponent => (T)_components.GetValue(original, c => fabric(c));
        public static void Remove(GameObject original) => _gameObjects.Remove(original);
        public static void Remove(Component original) => _components.Remove(original);
    }
}
