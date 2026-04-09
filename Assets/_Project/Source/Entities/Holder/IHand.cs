using IceFebruary;
using IceFebruary.Physics;

public interface IHand
{
    void Connect(IComponent<IHingeJoint2D> holder);
    void Disconnect();
}
