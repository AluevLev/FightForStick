namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.AutoGeneration;

    using HingeJoint2D = UnityEngine.HingeJoint2D;

    [UnityAnalog(typeof(HingeJoint2D))]
    public sealed class UnityHingeJoint2D : UnityBaseEntity<HingeJoint2D>, IHingeJoint2D
    {
        public UnityHingeJoint2D(HingeJoint2D hingeJoint2D) : base(hingeJoint2D) { }
        public Vector2 Anchor
        {
            get => Original.anchor.ToIce();
            set => Original.anchor = value.ToUnity();
        }
        public IRigidbody2D ConnectedBody
        {
            get => UnityMethods.Upsert(Original.connectedBody) as IRigidbody2D;
            set => Original.connectedBody = (value as UnityRigidbody2D)?.Original;
        }
    }
}
