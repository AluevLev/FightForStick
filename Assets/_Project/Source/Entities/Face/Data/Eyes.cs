using UnityEngine;
using IceFebruary.Render;

[CreateAssetMenu(fileName = "Eyes", menuName = "Face/Eyes")]
public class Eyes : ScriptableObject
{
    [SerializeField] private ISprite _eye1;
    [SerializeField] private ISprite _eye2;
    public ISprite Eye1 => _eye1;
    public ISprite Eye2 => _eye2;
}
