using UnityEngine;

public readonly struct Face
{
    private readonly Sprite _eye1;
    private readonly Sprite _eye2;
    private readonly Sprite _mouth;
    public readonly Sprite Eye1 => _eye1;
    public readonly Sprite Eye2 => _eye2;
    public readonly Sprite Mouth => _mouth;
    public Face(Sprite eye1, Sprite eye2, Sprite mouth)
    {
        _eye1 = eye1;
        _eye2 = eye2;
        _mouth = mouth;
    }
    public Face(Eyes eyes, Mouth mouth)
    {
        _eye1 = eyes.Eye1;
        _eye2 = eyes.Eye2;
        _mouth = mouth.Value;
    }
}
