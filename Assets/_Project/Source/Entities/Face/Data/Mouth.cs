using UnityEngine;
using IceFebruary.Render;

[CreateAssetMenu(fileName = "Mouth", menuName = "Face/Mouth")]
public class Mouth : ScriptableObject
{
	[SerializeField] private ISprite _mouth;
	public ISprite Value => _mouth;
}
