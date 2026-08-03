using IceFebruary;
using IceFebruary.Physics;

public readonly struct ItemHolder
{
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public IPhysicsBalancer PhysicsBalancer { get; private init; }

    public ItemHolder(Component<IHingeJoint2D>[] holders, IPhysicsBalancer physicsBalancer)
    {
        Holders = holders;
        PhysicsBalancer = physicsBalancer;
    }
}
