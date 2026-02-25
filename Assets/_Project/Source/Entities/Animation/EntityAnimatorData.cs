using UnityEngine;

[CreateAssetMenu(fileName = "Animator Data", menuName = "Animator Data")]
public class EntityAnimatorData : ScriptableObject, IEntityAnimatorData
{
	[SerializeReference, InterfaceImplementation] private IUnityAnimatorFieldName _walkAnimation;
    [SerializeReference, InterfaceImplementation] private IUnityAnimatorFieldName _sneakAnimation;
    private AnimatorFieldName _walk;
    private AnimatorFieldName _sneak;

    public int WalkAnimationHash => (_walk ??= _walkAnimation.GetAnimatorFieldName()).Hash;
    public int SneakAnimationHash => (_sneak ??= _sneakAnimation.GetAnimatorFieldName()).Hash;

#if UNITY_EDITOR
    private void OnDisable() { _walk = null; _sneak = null; }
#endif
}
