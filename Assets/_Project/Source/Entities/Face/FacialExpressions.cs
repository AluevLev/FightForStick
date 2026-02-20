using UnityEngine;
public class FacialExpressions
{
    private readonly SpriteRenderer _eye1;
    private readonly SpriteRenderer _eye2;
    private readonly SpriteRenderer _mouth;

    private readonly Animator _animator;
    private readonly GrimaceLibrary _grimaceLibrary;

    public FacialExpressions(SpriteRenderer eye1, SpriteRenderer eye2, SpriteRenderer mouth, Animator animator, GrimaceLibrary grimaceLibrary)
    {
        _eye1 = eye1;
        _eye2 = eye2;
        _mouth = mouth;
        _animator = animator;
        _grimaceLibrary = grimaceLibrary;
    }
    public void ChangeFaceToRandom() => ChangeFace(_grimaceLibrary.GetFace());
    public void ChangeFace(Face face)
    {
        _animator.SetTrigger("Pulse");

        _eye1.sprite = face.eye1;
        _eye2.sprite = face.eye2;
        _mouth.sprite = face.mouth;
    }
}
[System.Serializable]
public struct Face
{
    public Sprite eye1;
    public Sprite eye2;
    public Sprite mouth;
}