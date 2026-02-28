using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Physics Balancer Settings", menuName = "Physics Balancer Settings")]
public class PhysicsBalancerSettings : ScriptableObject
{
    [SerializeReference, InterfaceImplementation] private IPointProviderProxy _defaultTarget;
    [SerializeField, Range(0f, 1f)] private float _force;
    public IPointProvider DefaultTarget => _defaultTarget.ToPoco();
    public float Force => _force;
}
