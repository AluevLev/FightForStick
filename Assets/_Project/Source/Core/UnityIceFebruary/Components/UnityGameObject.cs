namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Components;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public class UnityGameObject : IGameObject, ITransform
    {
        private readonly UnityEngine.GameObject _gameObject;
        private readonly UnityEngine.Transform _transform;
        public UnityGameObject(UnityEngine.GameObject gameObject)
        {
            _gameObject = gameObject;
            _transform = gameObject.transform;
        }
        public bool Enabled
        {
            get => _gameObject.activeSelf;
            set => _gameObject.SetActive(value);
        }
        public IGameObject GameObject => this;
        public ITransform Transform => this;
        public Vector2 Position
        {
            get => _transform.position.ToUniversal();
            set
            {
                if (!Enabled)
                    return;

                _transform.position = value.ToUnity2D();
            }
        }
        public Vector2 LocalPosition
        {
            get => _transform.localPosition.ToUniversal();
            set
            {
                if (!Enabled)
                    return;

                _transform.localPosition = value.ToUnity2D();
            }
        }
        public Vector2 TransformDirection(Vector2 vector2) => _transform.TransformDirection(vector2.ToUnity3D()).ToUniversal();
        public bool TryGetComponent<T>(out T component) where T : class, IComponent
        {
            if (_gameObject.TryGetComponent(out T xyu))
            {
                component = xyu;
                return true;
            }

            component = null;
            return false;
        }
    }
}
