using IceFebruary;
using IceFebruary.Physics;

public interface IHand
{
    void Connect(Component<IHingeJoint2D> holder);
    void Disconnect();
}
