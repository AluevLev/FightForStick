using IceFebruary.Render;

public readonly struct Face
{
    public ISprite Eye1 { get; init; }
    public ISprite Eye2 { get; init; }
    public ISprite Mouth { get; init; }
    public Face(ISprite eye1, ISprite eye2, ISprite mouth)
    {
        Eye1 = eye1;
        Eye2 = eye2;
        Mouth = mouth;
    }
    public Face(Eyes eyes, Mouth mouth)
    {
        Eye1 = eyes.Eye1;
        Eye2 = eyes.Eye2;
        Mouth = mouth.Value;
    }
}
