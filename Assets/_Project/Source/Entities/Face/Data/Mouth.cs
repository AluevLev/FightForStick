using UnityEngine;

[CreateAssetMenu(fileName = "Mouth", menuName = "Face/Mouth")]
public class Mouth : ScriptableObject
{
	[SerializeField] private Sprite _mouth;
	public Sprite Value => _mouth;
}
