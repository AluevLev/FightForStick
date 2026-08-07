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
        public IBaseEntity MainComponent { get; set; }

        [FieldProxy(typeof(IGameObject))]
        public UnityGameObject(GameObject gameObject) : base(gameObject)
        {
            Transform = (ITransform)UnityMethods.Upsert(gameObject.transform);
        }
        public IRootConfig GetRootConfig()
        {
            if (!Original.TryGetComponent(out UnityInfo info))
                return null;

            IRootConfig rootConfig = info.ToPoco();

            Object.Destroy(info);

            return rootConfig;
        }
    }
}
