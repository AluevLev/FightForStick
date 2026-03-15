using IceFebruary;
using IceFebruary.Physics;

public class EntityHand : IHand
{
    private readonly IRigidbody2D _hand;
    private IEntireComponent<IHingeJoint2D> _holder;
    public EntityHand(IRigidbody2D hand)
    {
        _hand = hand;
    }
    public void Connect(IEntireComponent<IHingeJoint2D> holder)
    {
        _holder = holder;

        _hand.Position = _holder.GameObject.Transform.TransformPoint(_holder.Component.Anchor);

        _holder.Component.ConnectedBody = _hand;
        _holder.Component.Enabled = true;
    }
    public void Disconnect()
    {
        _holder.Component.Enabled = false;
        _holder.Component.ConnectedBody = null;
        _holder = null;
    }
}
