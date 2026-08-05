namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using UnityEngine;

    public sealed class UnityGameObject : UnityBaseEntity<GameObject>, IGameObject
    {
        public ITransform Transform { get; private init; }
        public int Layer
        {
            get => Original.layer;
            set => Original.layer = value;
        }
        public SetOnce<IBaseEntity> MainComponent { get; private init; } = new();
        private bool _instantiateInfoGetted;

        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = (ITransform)UnityMethods.Upsert(gameObject.transform);
        }
        public bool TryGetInstantiateInfo<T>(out T content) where T : struct
        {
            if (_instantiateInfoGetted)
            {
                content = default;
                return false;
            }

            _instantiateInfoGetted = true;

            if (Original.TryGetComponent(out UnityInstantiateInfo<T> context))
            {
                content = context.ToPoco();
                Object.Destroy(context);
                return true;
            }

            content = default;
            return false;
        }
    }
}
