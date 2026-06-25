using IceFebruary.Proxy;

public readonly struct RagdollSchema
{
    public PhysicsLimbSettings[] PhysicsLimbSettings { get; private init; }

    [FieldProxy]
    public RagdollSchema(PhysicsLimbSettings[] physicsLimbSettings)
    {
        PhysicsLimbSettings = physicsLimbSettings;
    }
}