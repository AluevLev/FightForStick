using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Proxy;

public readonly struct ShootingConfig
{
    public IGameObject GameObject { get; private init; }
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public PhysicsBalancerConfig PhysicsLimbConfig { get; private init; }
    public IVector2Provider ShootDirection { get; private init; }
    public IVector2Provider ShootPoint { get; private init; }
    public ShootingSettings Settings { get; private init; }

    [Proxy]
    public ShootingConfig(IGameObject gameObject, HingeJoint2DComponent[] holders, PhysicsBalancerConfig physicsLimbConfig,
        IVector2Provider shootDirection, IVector2Provider shootPoint, ShootingSettings settings)
    {
        GameObject = gameObject;

        Holders = new Component<IHingeJoint2D>[holders.Length];

        for (int index = 0; index < holders.Length; index++)
        {
            HingeJoint2DComponent hingeJoint2DComponent = holders[index];
            Holders[index] = new Component<IHingeJoint2D>(hingeJoint2DComponent.HingeJoint2D, hingeJoint2DComponent.GameObject);
        }

        PhysicsLimbConfig = physicsLimbConfig;
        ShootDirection = shootDirection;
        ShootPoint = shootPoint;
        Settings = settings;
    }
}
