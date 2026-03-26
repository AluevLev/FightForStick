namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration;

    using HingeJoint2D = UnityEngine.HingeJoint2D;

    [UnityAnalog(typeof(HingeJoint2D))]
    public class UnityHingeJoint2D : IHingeJoint2D, IUnityAnalog
    {
        public HingeJoint2D HingeJoint2D { get; private init; }
        public UnityEngine.Component Original { get; private init; }
        public UnityHingeJoint2D(HingeJoint2D hingeJoint2D)
        {
            HingeJoint2D = hingeJoint2D;
            Original = hingeJoint2D;
        }
        public bool Enabled
        {
            get => HingeJoint2D.enabled;
            set => HingeJoint2D.enabled = value;
        }
        public Vector2 Anchor
        {
            get => HingeJoint2D.anchor.ToIce();
            set => HingeJoint2D.anchor = value.ToUnity2D();
        }
        public IRigidbody2D ConnectedBody
        {
            get => new UnityRigidbody2D(HingeJoint2D.connectedBody);
            set => HingeJoint2D.connectedBody = (value as UnityRigidbody2D)?.Rigidbody2D;
        }
    }
}
