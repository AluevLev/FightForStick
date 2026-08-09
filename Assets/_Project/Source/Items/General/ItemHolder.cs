using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space.Follow;
using IceFebruary.Space.Rotor2Provider;

public sealed class ItemHolder : BaseEntity
{
    public IGameObject GameObject { get; private init; }
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public ITargetPossessing<IRotor2Provider> PhysicsBalancer { get; private init; }

    public ItemHolder(IGameObject gameObject, Component<IHingeJoint2D>[] holders, ITargetPossessing<IRotor2Provider> physicsBalancer)
    {
        GameObject = gameObject;
        Holders = holders;
        PhysicsBalancer = physicsBalancer;
    }
}
