namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using UnityEngine;

    public sealed class UnityGameObject : UnityBaseEntity<GameObject>, IGameObject
    {
        private IBaseEntity _mainComponent;
        public ITransform Transform { get; private init; }
        public IBaseEntity MainComponent
        {
            get => _mainComponent;
            private set
            {
                if (_mainComponentSetted || value == null)
                    return;

                _mainComponent = value;
                _mainComponentSetted = true;
            }
        }
        private bool _mainComponentSetted;
        private bool _instantiateInfoGetted;
        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = (ITransform)UnityMethods.Upsert(gameObject.transform);
        }
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
