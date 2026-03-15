using UnityEngine;
using IceFebruary.Physics;

[System.Serializable]
public struct PhysicsLimbSettings
{
    [SerializeField] private IRigidbody2D _rigidbody2D;
    [SerializeField] private PhysicsBalancerSettings _balancerSettings;
    public readonly IRigidbody2D Rigidbody2D => _rigidbody2D;
    public readonly PhysicsBalancerSettings BalancerSettings => _balancerSettings;
}
