using UnityEngine;
[CreateAssetMenu(fileName = "Grimaces", menuName = "Grimaces")]
public class GrimaceLibrary : ScriptableObject
{
    [System.Serializable]
    private struct EyesSprite
    {
        public Sprite eye1;
        public Sprite eye2;
    }
    [SerializeField] private EyesSprite[] _eyes;
    [SerializeField] private Sprite[] _mouths;
    public Face GetFace(int angryness = -1, int mood = -1)
    {
        if (_eyes.Length == 0 || _mouths.Length == 0)
            return default;

        EyesSprite eyesSprite = _eyes[angryness < 0 ? Random.Range(0, _eyes.Length) : angryness];
        Sprite mouthSprite = _mouths[mood < 0 ? Random.Range(0, _mouths.Length) : mood];
        return new Face { eye1 = eyesSprite.eye1, eye2 = eyesSprite.eye2, mouth = mouthSprite };
    }
}