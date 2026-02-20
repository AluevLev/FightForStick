using System;
using UnityEngine;

public class PhysicsBalancerSettings : ScriptableObject
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _defaultTarget;
    [SerializeField, Range(0f, 1f)] private float _force;
    public IPointProvider DefaultTarget => _defaultTarget;
    public float Force => _force;
}
