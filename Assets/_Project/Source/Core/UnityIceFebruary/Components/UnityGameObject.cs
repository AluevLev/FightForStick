namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    public sealed class UnityGameObject : UnityBaseEntity<GameObject>, IGameObject
    {
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = UnityMethods.Upsert(gameObject.transform) as ITransform2D;
        }
        public ITransform2D Transform { get; private init; }
        public bool TryGetComponent<T>(out T component) where T : class
        {
            System.Type type = UnityMethods.GetUnityType<T>();

            if (type == null)
            {
                component = null;
                return false;
            }

            if (Original.TryGetComponent(type, out Component getted))
            {
                component = UnityMethods.Upsert(getted) as T;
                return component != null;
            }

            component = null;
            return false;
        }
    }
}
