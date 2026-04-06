namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using Transform = UnityEngine.Transform;

    public sealed class UnityTransform : ITransform, IUnityAnalog
    {
        public Transform Transform { get; private init; }
        public UnityEngine.Object Original { get; private init; }
        public UnityTransform(Transform transform)
        {
            Transform = transform;
            Original = Transform;
        }
        public Vector2 Position
        {
            get => Transform.position.ToIce();
            set => Transform.position = value.ToUnity2D();
        }
        public Vector2 LocalPosition
        {
            get => Transform.localPosition.ToIce();
            set => Transform.localPosition = value.ToUnity2D();
        }
        public Vector2 TransformDirection(Vector2 vector2) => Transform.TransformDirection(vector2.ToUnity3D()).ToIce();
        public Vector2 TransformPoint(Vector2 vector2) => Transform.TransformPoint(vector2.ToUnity3D()).ToIce();
    }
}
