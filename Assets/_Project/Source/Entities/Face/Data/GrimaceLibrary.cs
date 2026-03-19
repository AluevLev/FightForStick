using IceFebruary.Collections;
using IceFebruary.Proxy;

public readonly struct GrimaceLibrary
{
    private readonly Eyes[] _eyes;
    private readonly Mouth[] _mouths;
    public Face DefaultFace { get; private init; }

    [ScriptableObjectProxy]
    public GrimaceLibrary(Eyes[] eyes, Mouth[] mouths, Face defaultFace = default)
    {
        _eyes = eyes;
        _mouths = mouths;
        DefaultFace = defaultFace;
    }
    public Face? GetFace(int angryness, int mood)
    {
        Eyes eyes = _eyes.GetSafetyElement(angryness);
        Mouth mouth = _mouths.GetSafetyElement(mood);

        return new(eyes.Eye1, eyes.Eye2, mouth.Value);
    }
}