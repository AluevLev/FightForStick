using UnityEngine;
using February;
using February.Random;

[CreateAssetMenu(fileName = "Grimaces", menuName = "Face/Grimaces")]
public class GrimaceLibrary : ScriptableObject
{
    [SerializeField] private Eyes _startEyes;
    [SerializeField] private Mouth _startMouth;
    [SerializeField] private Eyes[] _eyes;
    [SerializeField] private Mouth[] _mouths;
    private Face? _startFace;
    public Face GetFace(int angryness, int mood)
    {
        if (!_eyes.Exist() || !_mouths.Exist())
            return default;

        Eyes eyesSprite = GetFacePart(_eyes, angryness);
        Mouth mouthSprite = GetFacePart(_mouths, mood);
        return new(eyesSprite.Eye1, eyesSprite.Eye2, mouthSprite.Value);
    }
    public Face GetStartFace()
    {
        if (!_startFace.HasValue)
            _startFace = new(_startEyes, _startMouth);
        return _startFace.Value;
    }
    private T GetFacePart<T>(T[] array, int index) => index switch
    {
        FacePart.Empty => default,
        FacePart.Random => GlobalRandom.InArray(array),
        _ => array[Mathf.Clamp(index, 0, array.Length - 1)]
    };
}