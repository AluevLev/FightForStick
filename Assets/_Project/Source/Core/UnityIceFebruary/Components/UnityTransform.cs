namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Transform = UnityEngine.Transform;

    public sealed class UnityTransform : UnityBaseEntity<Transform>, ITransform2D
    {
        public UnityTransform(Transform transform) : base(transform) { }
        public Vector2 Position
        {
            get => Original.position.ToIce();
            set => Original.position = value.ToUnity();
        }
        public Rotor2 Rotation
        {
            get => Original.rotation.ToIce();
            set => Original.rotation = value.ToUnity();
        }
        public Vector2 LocalPosition
        {
            get => Original.localPosition.ToIce();
            set => Original.localPosition = value.ToUnity();
        }
        public Rotor2 LocalRotation
        {
            get => Original.localRotation.ToIce();
            set => Original.localRotation = value.ToUnity();
        }
        public Vector2 TransformDirection(Vector2 vector2) => Original.TransformDirection(vector2.ToUnity()).ToIce();
        public Vector2 TransformPoint(Vector2 vector2) => Original.TransformPoint(vector2.ToUnity()).ToIce();
    }
}
