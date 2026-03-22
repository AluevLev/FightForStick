// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "PickUpSettingsProxy", menuName = "Proxy/PickUpSettings")]
public class PickUpSettingsProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeField] private float _maxPickUpDistance;
    public PickUpSettings ToPoco() => new(_maxPickUpDistance);
}
