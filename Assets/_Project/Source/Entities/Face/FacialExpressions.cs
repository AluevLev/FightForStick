using System.Collections;
using UnityEngine;
public class FacialExpressions : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _eye1;
    [SerializeField] private SpriteRenderer _eye2;
    [SerializeField] private SpriteRenderer _mouth;

    [SerializeField] private Animator _animator;
    [SerializeField] private GrimaceLibrary _grimaceLibrary;

    private void Start()
    {
        StartCoroutine(ChangeFaceCoroutine());
    }
    private IEnumerator ChangeFaceCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            ChangeFace(_grimaceLibrary.GetFace());
        }
    }
    private void ChangeFace(Face face)
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