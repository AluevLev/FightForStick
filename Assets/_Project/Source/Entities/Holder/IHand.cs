using IceFebruary;
using IceFebruary.Physics;

public interface IHand
{
    void Connect(Component<IHingeJoint2D> hingeJoint2D);
    void Disconnect();
}
