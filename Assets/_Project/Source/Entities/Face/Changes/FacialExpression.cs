using IceFebruary.Animation;
using IceFebruary.Render;

public class FacialExpression : IFacialExpression
{
    private readonly AnimatorTrigger _pulseTrigger;

    private readonly ISpriteRenderer _eye1;
    private readonly ISpriteRenderer _eye2;
    private readonly ISpriteRenderer _mouth;

    public FacialExpression(ISpriteRenderer eye1, ISpriteRenderer eye2, ISpriteRenderer mouth, AnimatorTrigger pulseTrigger)
    {
        _eye1 = eye1;
        _eye2 = eye2;
        _mouth = mouth;
        _pulseTrigger = pulseTrigger;
    }
    public void ChangeFace(Face face)
    {
        _pulseTrigger.Set();

        _eye1.Sprite = face.Eye1;
        _eye2.Sprite = face.Eye2;
        _mouth.Sprite = face.Mouth;
    }
}