namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using UnityEngine;

    public sealed class UnityGameObject2D : UnityBaseEntity<GameObject>, IGameObject
    {
        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject2D(GameObject gameObject) : base(gameObject)
        {
            Transform = (ITransform2D)UnityMethods.Upsert(gameObject.transform);
        }
        public ITransform2D Transform { get; private init; }
        public bool TryGetComponent<T>(out T component) where T : class, IBaseEntity
        {
            System.Type type = UnityMethods.GetUnityType<T>();

            if (type != null && Original.TryGetComponent(type, out Component getted))
            {
                component = (T)UnityMethods.Upsert(getted);
                return component.Exists();
            }

            component = null;
            return false;
        }
        public bool TryGetContext<T>(out T content) where T : struct
        {
            if (Original.TryGetComponent(out IInstantiateInfo<T> context))
            {
                content = context.ToPoco();
                Object.Destroy((MonoBehaviour)context);
                return true;
            }

            content = default;
            return false;
        }
    }
}
