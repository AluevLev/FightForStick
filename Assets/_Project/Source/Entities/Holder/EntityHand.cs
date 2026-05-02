using IceFebruary;
using IceFebruary.Physics;

public sealed class EntityHand : IHand
{
    private readonly Component<IRigidbody2D> _hand;
    private Component<IHingeJoint2D> _holder;
    public EntityHand(Component<IRigidbody2D> hand)
    {
        _hand = hand;
    }
    public void Connect(Component<IHingeJoint2D> holder)
    {
        _holder = holder;

        if (!Unpack(out IRigidbody2D rigidbody2D, out IHingeJoint2D hingeJoint2D, out IGameObject handGameObject, out IGameObject holderGameObject))
            return;
        
        handGameObject.Transform.Position = holderGameObject.Transform.TransformPoint(hingeJoint2D.Anchor);
        hingeJoint2D.ConnectedBody = rigidbody2D;
        hingeJoint2D.Enabled = true;
    }
    public void Disconnect()
    {
        if (!Unpack(out IRigidbody2D rigidbody2D, out IHingeJoint2D hingeJoint2D, out IGameObject handGameObject, out IGameObject holderGameObject))
            return;

        hingeJoint2D.Enabled = false;
        hingeJoint2D.ConnectedBody = null;
    }
    private bool Unpack(out IRigidbody2D rigidbody2D, out IHingeJoint2D hingeJoint2D, out IGameObject handGameObject, out IGameObject holderGameObject) =>
        !_hand.Unpack(out rigidbody2D, out handGameObject) & !_holder.Unpack(out hingeJoint2D, out holderGameObject);
}
