using UnityEngine;

[System.Serializable]
public struct PhysicsLimbSettings
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private PhysicsBalancerSettings _balancerSettings;
    public readonly Rigidbody2D Rigidbody2D => _rigidbody2D;
    public readonly PhysicsBalancerSettings BalancerSettings => _balancerSettings;
}
