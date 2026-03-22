// AUTO-GENERATED. DO NOT EDIT.
[UnityEngine.CreateAssetMenu(fileName = "EntityAnimatorDataProxy", menuName = "Proxy/EntityAnimatorData")]
public class EntityAnimatorDataProxy : UnityEngine.ScriptableObject
{
    [UnityEngine.SerializeField] private int _walkAnimationHash;
    [UnityEngine.SerializeField] private int _sneakAnimationHash;
    public EntityAnimatorData ToPoco() => new(_walkAnimationHash, _sneakAnimationHash);
}
