namespace February.Components.UnityStandart
{
    using February;
    using February.Adaptation;
    using February.Components;
    using February.Space;
    using UnityEngine;

    public class StandartTransform : ITogglable, ITransform
    {
        private readonly Transform _transform;
        public bool Enabled { get; set; } = true;
        public StandartTransform(Transform transform)
        {
            _transform = transform;
        }
        public UniVector2 Position
        {
            get => _transform.position.ToUniversal();
            set => _transform.position = value.ToUnity2D();
        }
        public UniVector2 LocalPosition
        {
            get => _transform.localPosition.ToUniversal();
            set => _transform.localPosition = value.ToUnity2D();
        }
        public UniVector2 TransformDirection(UniVector2 vector2) => _transform.TransformDirection(vector2.ToUnity3D()).ToUniversal();
    }
}
