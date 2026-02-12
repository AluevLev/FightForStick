using System;
using UnityEngine;

[Serializable]
public struct PhysicsBalancerSettings
{
    [SerializeReference, InterfaceImplementation] private IPointProvider _defaultTarget;
    [SerializeField] private float _stiffness;
    [SerializeField] private float _damping;
}
