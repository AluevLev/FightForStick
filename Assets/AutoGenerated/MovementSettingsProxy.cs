// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "MovementSettingsProxy", menuName = "Proxy/MovementSettings")]
public class MovementSettingsProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeField] private float _speed;
    [UnityEngine.SerializeField] private float _jumpForce;
    [UnityEngine.SerializeField] private float _jumpBoost;
    public MovementSettings ToPoco() => new(_speed, _jumpForce, _jumpBoost);
}
