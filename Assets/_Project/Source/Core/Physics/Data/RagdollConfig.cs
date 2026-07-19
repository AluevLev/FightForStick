using IceFebruary.Proxy;

public readonly struct RagdollConfig
{
    public PhysicsLimbConfig Head { get; private init; }
    public PhysicsLimbConfig Body { get; private init; }
    public PhysicsLimbConfig Hip1 { get; private init; }
    public PhysicsLimbConfig Shin1 { get; private init; }
    public PhysicsLimbConfig Foot1 { get; private init; }
    public PhysicsLimbConfig Hip2 { get; private init; }
    public PhysicsLimbConfig Shin2 { get; private init; }
    public PhysicsLimbConfig Foot2 { get; private init; }

    [FieldProxy]
    public RagdollConfig(PhysicsLimbConfig head, PhysicsLimbConfig body,
        PhysicsLimbConfig hip1, PhysicsLimbConfig shin1, PhysicsLimbConfig foot1,
        PhysicsLimbConfig hip2, PhysicsLimbConfig shin2, PhysicsLimbConfig foot2)
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