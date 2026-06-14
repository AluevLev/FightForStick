using IceFebruary;
using IceFebruary.Physics;

public sealed class EntityHand : BaseEntity, IHand
{
    private readonly Component<IRigidbody2D> _hand;
    private IHingeJoint2D _holderHingeJoint2D;
    public EntityHand(Component<IRigidbody2D> hand) : base()
    {
        _hand = hand;
    }
    public void Connect(Component<IHingeJoint2D> holder)
    {
        _holderHingeJoint2D = holder.Value;

        _hand.Transform.Position = holder.GameObject.Transform.TransformPoint(_holderHingeJoint2D.Anchor);
        _holderHingeJoint2D.ConnectedBody = _hand.Value;
        _holderHingeJoint2D.Enabled = true;
    }
    public void Disconnect()
    {
        _holderHingeJoint2D.Enabled = false;
        _holderHingeJoint2D.ConnectedBody = null;
        _holderHingeJoint2D = null;
    }
}
