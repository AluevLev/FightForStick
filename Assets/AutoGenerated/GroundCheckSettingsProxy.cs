// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "GroundCheckSettingsProxy", menuName = "Proxy/GroundCheckSettings")]
public class GroundCheckSettingsProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeField] private IceFebruary.Space.Vector2 _groundCheckSize;
    [UnityEngine.SerializeField] private IceFebruary.Physics.ContactFilter2D _contactFilter2D;
    public GroundCheckSettings ToPoco() => new(_groundCheckSize, _contactFilter2D);
}
