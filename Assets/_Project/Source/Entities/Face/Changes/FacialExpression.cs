using UnityEngine;
using IceFebruary.Animation;

public class FacialExpression : IFacialExpression
{
    private readonly AnimatorTrigger _pulseTrigger;

    private readonly SpriteRenderer _eye1;
    private readonly SpriteRenderer _eye2;
    private readonly SpriteRenderer _mouth;

    public FacialExpression(SpriteRenderer eye1, SpriteRenderer eye2, SpriteRenderer mouth, AnimatorTrigger pulseTrigger)
    {
        _eye1 = eye1;
        _eye2 = eye2;
        _mouth = mouth;
        _pulseTrigger = pulseTrigger;
    }
    public void ChangeFace(Face face)
    {
        _pulseTrigger.Set();

        _eye1.sprite = face.Eye1;
        _eye2.sprite = face.Eye2;
        _mouth.sprite = face.Mouth;
    }
}