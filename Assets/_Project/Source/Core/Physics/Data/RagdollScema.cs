using UnityEngine;
using System;

[Serializable]
public class RagdollScema
{
    [Header("Head")]
    [SerializeField] private PhysicsLimbSettings _head;
    [Header("Body")]
    [SerializeField] private PhysicsLimbSettings _body;
    [Header("Arm 1")]
    [SerializeField] private PhysicsLimbSettings _shoulder1;
    [SerializeField] private PhysicsLimbSettings _forearm1;
    [SerializeField] private PhysicsLimbSettings _hand1;
    [Header("Arm 2")]
    [SerializeField] private PhysicsLimbSettings _shoulder2;
    [SerializeField] private PhysicsLimbSettings _forearm2;
    [SerializeField] private PhysicsLimbSettings _hand2;
    [Header("Leg 1")]
    [SerializeField] private PhysicsLimbSettings _hip1;
    [SerializeField] private PhysicsLimbSettings _shin1;
    [SerializeField] private PhysicsLimbSettings _foot1;
    [Header("Leg 2")]
    [SerializeField] private PhysicsLimbSettings _hip2;
    [SerializeField] private PhysicsLimbSettings _shin2;
    [SerializeField] private PhysicsLimbSettings _foot2;
    public PhysicsLimbSettings[] ToArray() => new PhysicsLimbSettings[]
    {
        _head,
            _body,
            _shoulder1, _forearm1, _hand1,
            _shoulder2, _forearm2, _hand2,
            _hip1, _shin1, _foot1,
            _hip2, _shin2, _foot2
    };
}