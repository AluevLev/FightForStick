using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct ItemSettings
{
    public IGameObject GameObject { get; private init; }
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public PhysicsBalancerConfig PhysicsLimbConfig { get; private init; }

    [FieldProxy]
    public ItemSettings(IGameObject gameObject, Component<IHingeJoint2D>[] holders, PhysicsBalancerConfig physicsLimbConfig)
    {
        GameObject = gameObject;

        Holders = holders;

        PhysicsLimbConfig = physicsLimbConfig;
    }
}
