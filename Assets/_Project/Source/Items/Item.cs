using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : BaseEntity, IPickable
{
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public IPhysicsBalancer PhysicsBalancer { get; private init; }
    public Item(Component<IHingeJoint2D>[] holders, IPhysicsBalancer physicsBalancer)
    {
        Holders = holders;
        PhysicsBalancer = physicsBalancer;
    }
}
