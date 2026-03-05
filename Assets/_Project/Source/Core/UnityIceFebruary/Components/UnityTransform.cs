namespace UnityIceFebruary.Components
{
    using UnityIceFebruary.Adaptation;
    using IceFebruary;
    using IceFebruary.Components;
    using IceFebruary.Space;
    using UnityEngine;

    public class UnityTransform : ITogglable, ITransform
    {
        private readonly Transform _transform;
        public bool Enabled { get; set; } = true;
        public UnityTransform(Transform transform)
        {
            _transform = transform;
        }
        public IceFebruary.Space.Vector2 Position
        {
            get => _transform.position.ToUniversal();
            set => _transform.position = value.ToUnity2D();
        }
        public IceFebruary.Space.Vector2 LocalPosition
        {
            get => _transform.localPosition.ToUniversal();
            set => _transform.localPosition = value.ToUnity2D();
        }
        public IceFebruary.Space.Vector2 TransformDirection(IceFebruary.Space.Vector2 vector2) => _transform.TransformDirection(vector2.ToUnity3D()).ToUniversal();
    }
}
