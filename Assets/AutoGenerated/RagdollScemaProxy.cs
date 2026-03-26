// AUTO-GENERATED. DO NOT EDIT.
[System.Serializable]
public class RagdollScemaProxy
{
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _head;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _body;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _shoulder1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _forearm1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _hand1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _shoulder2;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _forearm2;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _hand2;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _hip1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _shin1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _foot1;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _hip2;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _shin2;
    [UnityEngine.SerializeField] private PhysicsLimbSettingsProxy _foot2;
    public RagdollScema ToPoco() => new(_head.ToPoco(), _body.ToPoco(), _shoulder1.ToPoco(), _forearm1.ToPoco(), _hand1.ToPoco(), _shoulder2.ToPoco(), _forearm2.ToPoco(), _hand2.ToPoco(), _hip1.ToPoco(), _shin1.ToPoco(), _foot1.ToPoco(), _hip2.ToPoco(), _shin2.ToPoco(), _foot2.ToPoco());
}
