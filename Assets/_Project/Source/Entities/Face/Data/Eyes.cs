using UnityEngine;

[CreateAssetMenu(fileName = "Eyes", menuName = "Face/Eyes")]
public class Eyes : ScriptableObject
{
    [SerializeField] private Sprite _eye1;
    [SerializeField] private Sprite _eye2;
    public Sprite Eye1 => _eye1;
    public Sprite Eye2 => _eye2;
}
