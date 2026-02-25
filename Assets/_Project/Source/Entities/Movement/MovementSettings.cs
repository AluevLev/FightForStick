using UnityEngine;
[CreateAssetMenu(fileName = "Movement Settings", menuName = "Easy Data Holder/Movement Settings")]
public class MovementSettings : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpBoost;

    public float Speed => _speed;
    public float JumpForce => _jumpForce;
    public float JumpBoost => _jumpBoost;
}
