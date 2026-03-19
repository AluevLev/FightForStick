namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public class UnityHingeJoint2D : IHingeJoint2D
    {
        public UnityEngine.HingeJoint2D HingeJoint2D { get; private init; }
        public UnityHingeJoint2D(UnityEngine.HingeJoint2D hingeJoint2D)
        {
            HingeJoint2D = hingeJoint2D;
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
