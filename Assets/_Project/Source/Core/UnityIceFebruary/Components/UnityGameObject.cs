namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityGameObject : IGameObject, IUnityAnalog
    {
        public UnityEngine.GameObject GameObject { get; private init; }
        public UnityEngine.Object Original { get; private init; }
        public UnityGameObject(UnityEngine.GameObject gameObject)
        {
            GameObject = gameObject;
            Original = GameObject;
            Transform = UnityMethods.Upsert(gameObject.transform) as ITransform;
        }
        public ITransform Transform { get; private init; }
        public bool TryGetComponent<T>(out T component) where T : class, IComponent
        {
            System.Type type = UnityMethods.GetUnityType<T>();

            if (type == null)
            {
                component = null;
                return false;
            }

            if (GameObject.TryGetComponent(type, out UnityEngine.Component getted))
            {
                component = UnityMethods.Upsert(getted) as T;
                return component != null;
            }

            component = null;
            return false;
        }
    }
}
