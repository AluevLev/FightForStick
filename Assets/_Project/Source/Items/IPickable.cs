using IceFebruary.Physics;
using IceFebruary;

public interface IPickable : IBaseEntity
{
    Component<IHingeJoint2D>[] Holders { get; }
    IPhysicsBalancer PhysicsBalancer { get; }
}
