using IceFebruary.Proxy;

public readonly struct EntityAnimatorData
{
    public int WalkAnimationHash { get; private init; }
    public int SneakAnimationHash { get; private init; }

    [ScriptableObjectProxy]
    public EntityAnimatorData(int walkAnimationHash, int sneakAnimationHash)
    {
        WalkAnimationHash = walkAnimationHash;
        SneakAnimationHash = sneakAnimationHash;
    }
}
