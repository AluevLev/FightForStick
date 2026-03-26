// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class PhysicsLimbSettingsProxy
{
    [UnityEngine.SerializeReference, UnityIceFebruary.InterfaceImplementation.InterfaceImplementation] private IceFebruary.Physics.IRigidbody2D _rigidbody2D;
    [UnityEngine.SerializeField] private PhysicsBalancerSettingsProxy _balancerSettings;
    public PhysicsLimbSettings ToPoco() => new(_rigidbody2D, _balancerSettings.ToPoco());
}
