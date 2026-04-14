using IceFebruary;
using IceFebruary.Physics;

public sealed class EntityHand : IHand
{
    private readonly IComponent<IRigidbody2D> _hand;
    private IComponent<IHingeJoint2D> _holder;
    public EntityHand(IInnerPossessable<IRigidbody2D> hand)
    {
        //_hand = hand;
    }
    public void Connect(IComponent<IHingeJoint2D> holder)
    {
        _holder = holder;


        _hand.Transform.Position = _holder.GameObject.Transform.TransformPoint(_holder.Component.Anchor);

        _holder.Component.ConnectedBody = _hand.Component;
        //_holder.Component.Toggle.Enabled = true;
    }
    public void Disconnect()
    {
        //_holder.Component.Enabled = false;
        _holder.Component.ConnectedBody = null;
        _holder = null;
    }
}
