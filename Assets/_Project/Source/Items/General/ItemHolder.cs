using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Physics.Balancer;

public readonly struct ItemHolder
{
    public IGameObject GameObject { get; private init; }
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public IPhysicsBalancer PhysicsBalancer { get; private init; }

    public ItemHolder(IGameObject gameObject, Component<IHingeJoint2D>[] holders, IPhysicsBalancer physicsBalancer)
    {
        GameObject = gameObject;
        Holders = holders;
        PhysicsBalancer = physicsBalancer;
    }
}
