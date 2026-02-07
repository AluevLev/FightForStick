using UnityEngine;
using VContainer.Unity;

public class PhysicsCalculator : IStartable
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _defaultPointProvider;
    [SerializeField, Range(0f, 1f)] private float _force;
    private IPointProvider _targetPoint;
    public void Start()
    {

    }
}
