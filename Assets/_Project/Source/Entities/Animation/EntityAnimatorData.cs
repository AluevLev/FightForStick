using UnityEngine;


[CreateAssetMenu(fileName = "Animator Data", menuName = "Animator Data")]
public class EntityAnimatorData : ScriptableObject, IEntityAnimatorData
{
    //[SerializeField] private AnimatorFieldNameProxy _walkAnimation;
    //[SerializeField] private AnimatorFieldNameProxy _sneakAnimation;

    public int WalkAnimationHash => 0;//_walkAnimation.ToPoco().Hash;
    public int SneakAnimationHash => 0;//_sneakAnimation.ToPoco().Hash;
}
