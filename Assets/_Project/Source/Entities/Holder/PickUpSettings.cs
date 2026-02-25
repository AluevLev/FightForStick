using UnityEngine;

[CreateAssetMenu(fileName = "Pick Up")]
public class PickUpSettings : ScriptableObject
{
    [SerializeField] private float _maxPickUpDistance;
    public float MaxPickUpDistance => _maxPickUpDistance;
}
