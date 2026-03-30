namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public class UnityGameObject : IGameObject, ITransform, ITogglable
    {
        public UnityEngine.GameObject GameObject { get; private init; }
        private readonly UnityEngine.Transform _transform;
        public UnityGameObject(UnityEngine.GameObject gameObject)
        {
            GameObject = gameObject;
            _transform = gameObject.transform;
        }
        public bool Enabled
        {
            get => GameObject.activeSelf;
            set => GameObject.SetActive(value);
        }
        public bool IsValid => GameObject != null;
        public ITransform Transform => this;
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
        public Vector2 Position
        {
            get => _transform.position.ToIce();
            set
            {
                if (!Enabled)
                    return;

                _transform.position = value.ToUnity2D();
            }
        }
        public Vector2 LocalPosition
        {
            get => _transform.localPosition.ToIce();
            set
            {
                if (!Enabled)
                    return;

                _transform.localPosition = value.ToUnity2D();
            }
        }
        public Vector2 TransformDirection(Vector2 vector2) => _transform.TransformDirection(vector2.ToUnity3D()).ToIce();
        public Vector2 TransformPoint(Vector2 vector2) => _transform.TransformPoint(vector2.ToUnity3D()).ToIce();
    }
}
