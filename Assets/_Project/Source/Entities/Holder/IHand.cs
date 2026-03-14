using IceFebruary;
using IceFebruary.Physics;

public interface IHand
{
    void Connect(IFullDataComponent<IHingeJoint2D> holder);
    void Disconnect();
}
