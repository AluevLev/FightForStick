using System.Collections;
using UnityEngine;
using VContainer;
public class FacialExpressions : MonoBehaviour
{
    [SerializeField] private Transform _face;

    [SerializeField] private SpriteRenderer _eye1;
    [SerializeField] private SpriteRenderer _eye2;
    [SerializeField] private SpriteRenderer _mouth;

    [SerializeField] private Animator _animator;
    [SerializeField] private GrimaceLibrary _grimaceLibrary;

    [SerializeField] private float _maxDistancing;

    private IScreenInWorld _screenInWorld;
    public Transform Target
    {
        get;
        set;
    }
    [Inject]
    public void Construct(IScreenInWorld screenInWorld)
    {
        _screenInWorld = screenInWorld;
    }

    private void Start()
    {
        StartCoroutine(ChangeFaceCoroutine());
    }
    private void Update()
    {
        LookAtTarget();
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
    private void LookAtTarget()
    {
        Vector3 targetPosition = Target ? Target.position : _screenInWorld.MousePosition;
        Vector3 direction = (targetPosition - transform.position).normalized;
        Vector3 rotateDirection = Quaternion.Euler(Vector3.forward * -transform.eulerAngles.z) * direction;
        _face.localPosition = rotateDirection * _maxDistancing;
    }
}
[System.Serializable]
public struct Face
{
    public Sprite eye1;
    public Sprite eye2;
    public Sprite mouth;
}