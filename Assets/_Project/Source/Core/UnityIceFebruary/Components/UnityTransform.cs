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
        public Vector3 Position
        {
            get => Original.position.ToIce();
            set => Original.position = value.ToUnity();
        }
        public Rotor3 Rotation
        {
            get => Original.rotation.ToIce();
            set => Original.rotation = value.ToUnity();
        }
        public Vector3 LocalPosition
        {
            get => Original.localPosition.ToIce();
            set => Original.localPosition = value.ToUnity();
        }
        public Rotor3 LocalRotation
        {
            get => Original.localRotation.ToIce();
            set => Original.localRotation = value.ToUnity();
        }
        public Vector3 TransformDirection(Vector3 v) => Original.TransformDirection(v.ToUnity()).ToIce();
        public Vector3 TransformPoint(Vector3 v) => Original.TransformPoint(v.ToUnity()).ToIce();
    }
}
