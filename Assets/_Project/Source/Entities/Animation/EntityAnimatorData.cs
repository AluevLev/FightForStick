using IceFebruary.Proxy;

public readonly struct EntityAnimatorData
{
    public int WalkAnimationHash { get; init; }
    public int SneakAnimationHash { get; init; }

    [GenerateScriptableObjectProxy]
    public EntityAnimatorData(int walkAnimationHash, int sneakAnimationHash)
    {
        WalkAnimationHash = walkAnimationHash;
        SneakAnimationHash = sneakAnimationHash;
    }
}
