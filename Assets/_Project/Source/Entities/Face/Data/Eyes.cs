using IceFebruary.Proxy;
using IceFebruary.Render;

public readonly struct Eyes
{
    public ISprite Eye1 { get; init; }
    public ISprite Eye2 { get; init; }

    [GenerateScriptableObjectProxy]
    public Eyes(ISprite eye1, ISprite eye2)
    {
        Eye1 = eye1;
        Eye2 = eye2;
    }
}
