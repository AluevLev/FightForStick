using IceFebruary;
using IceFebruary.Physics;

public sealed class EntityHand : IHand
{
    private readonly IRigidbody2D _hand;
    private IHingeJoint2D _holderHingeJoint2D;
    public EntityHand(IRigidbody2D hand)
    {
        _hand = hand;
    }
    public void Connect(Component<IHingeJoint2D> holder)
    {
        IHingeJoint2D hingeJoint2D = holder.Value;
        IGameObject gameObject = holder.GameObject;

        if (!_hand.Exists() || !hingeJoint2D.Exists() || !gameObject.Exists())
            return;

        _holderHingeJoint2D = hingeJoint2D;

        _hand.Position = gameObject.Transform.TransformPoint(_holderHingeJoint2D.Anchor);
        _holderHingeJoint2D.ConnectedBody = _hand;
        _holderHingeJoint2D.Enabled = true;
    }
    public void Disconnect()
    {
        if (!_holderHingeJoint2D.Exists())
            return;

        _holderHingeJoint2D.Enabled = false;
        _holderHingeJoint2D.ConnectedBody = null;
        _holderHingeJoint2D = null;
    }
}
