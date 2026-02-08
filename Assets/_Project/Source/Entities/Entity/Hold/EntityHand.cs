using UnityEngine;

public class EntityHand : IHand
{
    private readonly Rigidbody2D _hand;
    private HingeJoint2D _holder;
    public EntityHand(Rigidbody2D hand)
    {
        _hand = hand;
    }
    public void Connect(HingeJoint2D holder)
    {
        _holder = holder;

        _hand.position = _holder.transform.TransformPoint(_holder.anchor);

        _holder.connectedBody = _hand;
        _holder.enabled = true;
    }
    public void Disconnect()
    {
        _holder.enabled = false;
        _holder.connectedBody = null;
        _holder = null;
    }
}
