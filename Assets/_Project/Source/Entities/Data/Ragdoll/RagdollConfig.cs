using IceFebruary.Proxy;

public readonly struct RagdollConfig
{
    public PhysicsBalancerConfig Head { get; private init; }
    public PhysicsBalancerConfig Body { get; private init; }
    public PhysicsBalancerConfig Hip1 { get; private init; }
    public PhysicsBalancerConfig Shin1 { get; private init; }
    public PhysicsBalancerConfig Foot1 { get; private init; }
    public PhysicsBalancerConfig Hip2 { get; private init; }
    public PhysicsBalancerConfig Shin2 { get; private init; }
    public PhysicsBalancerConfig Foot2 { get; private init; }

    [FieldProxy]
    public RagdollConfig(PhysicsBalancerConfig head, PhysicsBalancerConfig body,
        PhysicsBalancerConfig hip1, PhysicsBalancerConfig shin1, PhysicsBalancerConfig foot1,
        PhysicsBalancerConfig hip2, PhysicsBalancerConfig shin2, PhysicsBalancerConfig foot2)
    {
        Head = head;
        Body = body;

        Hip1 = hip1;
        Shin1 = shin1;
        Foot1 = foot1;

        Hip2 = hip2;
        Shin2 = shin2;
        Foot2 = foot2;
    }
}