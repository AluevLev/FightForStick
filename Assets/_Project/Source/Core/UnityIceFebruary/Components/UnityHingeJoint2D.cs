namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration;

    using HingeJoint2D = UnityEngine.HingeJoint2D;

    [UnityAnalog(typeof(HingeJoint2D))]
    public sealed class UnityHingeJoint2D : IHingeJoint2D, IUnityAnalog
    {
        public HingeJoint2D HingeJoint2D { get; private init; }
        public UnityEngine.Object Original { get; private init; }
        public UnityHingeJoint2D(HingeJoint2D hingeJoint2D)
        {
            HingeJoint2D = hingeJoint2D;
            Original = hingeJoint2D;
        }
        public Vector2 Anchor
        {
            get => HingeJoint2D.anchor.ToIce();
            set => HingeJoint2D.anchor = value.ToUnity2D();
        }
        public IRigidbody2D ConnectedBody
        {
            get => UnityMethods.Upsert(HingeJoint2D.connectedBody) as IRigidbody2D;
            set => HingeJoint2D.connectedBody = (value as UnityRigidbody2D)?.Rigidbody2D;
        }
    }
}
