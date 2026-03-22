// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "PhysicsBalancerSettingsProxy", menuName = "Proxy/PhysicsBalancerSettings")]
public class PhysicsBalancerSettingsProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IPointProviderProxy _target;
    [UnityEngine.SerializeField] private float _force;
    public PhysicsBalancerSettings ToPoco() => new(_target?.ToPoco(), _force);
}
