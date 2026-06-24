namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Proxy;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Transform = UnityEngine.Transform;

    public sealed class UnityTransform : UnityBaseEntity<Transform>, ITransform
    {
        [FieldProxy(typeof(ITransform))]
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
        public Vector2 TransformDirection(Vector2 v) => Original.TransformDirection(v.ToUnity()).ToIce();
        public Vector2 TransformPoint(Vector2 v) => Original.TransformPoint(v.ToUnity()).ToIce();
    }
}
