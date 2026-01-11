using UnityEngine;
[CreateAssetMenu(fileName = "Ground Check Settings", menuName = "Easy Data Holder/Ground Check Settings")]
public class GroundCheckSettings : ScriptableObject
{
    [SerializeField] private Vector2 _groundCheckSize;
    [SerializeField] private ContactFilter2D _contactFilter2D;

    public Vector2 GroundCheckSize => _groundCheckSize;
    public ContactFilter2D ContactFilter2D => _contactFilter2D;
}
