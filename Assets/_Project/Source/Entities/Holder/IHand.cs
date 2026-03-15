using IceFebruary;
using IceFebruary.Physics;

public interface IHand
{
    void Connect(IEntireComponent<IHingeJoint2D> holder);
    void Disconnect();
}
