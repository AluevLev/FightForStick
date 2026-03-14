using VContainer.Unity;
using IceFebruary;
using IceFebruary.Physics;
using UnityIceFebruary.Components;
public class RagdollCore : ITogglable, IRagdollCore, IFixedTickable
{
    private readonly IPhysicsBalancer[] _balancers;
    public bool Enabled { get; set; } = true;
    public RagdollCore(PhysicsLimbSettings[] settings)
    {
        _balancers = new IPhysicsBalancer[settings.Length];

        for (int limb = 0; limb < settings.Length; limb++)
        {
            PhysicsLimbSettings physicsBalancer = settings[limb];
            PhysicsBalancerSettings physicsBalancerSettings = physicsBalancer.BalancerSettings;
            /*
            IGameObject gameObject = new UnityGameObject(physicsBalancer.Rigidbody2D.gameObject);
            IRigidbody2D physicsBody = new UnityRigidbody2D(physicsBalancer.Rigidbody2D, gameObject);
            IPhysicsBalancerCalculator physicsBalancerCalculator = new PhysicsBalancerCalculator(physicsBalancerSettings.Force);

            IPhysicsBalancer balancer = new PhysicsBalancer(physicsBody, physicsBalancerCalculator, physicsBalancerSettings.DefaultTarget);
            _balancers[limb] = balancer;
            */
        }
    }
    public void FixedTick()
    {
        ProcessLimbs();
    }
    public void ProcessLimbs()
    {
        if (!Enabled)
            return;

        foreach (IPhysicsBalancer physicsBalancer in _balancers)
            physicsBalancer.LookAtTarget();
    }
}
