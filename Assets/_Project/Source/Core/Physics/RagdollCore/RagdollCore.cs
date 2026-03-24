using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Execution;

public class RagdollCore : ITogglable, IRagdollCore, IFixedFrame
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
            
            IRigidbody2D physicsBody = physicsBalancer.Rigidbody2D;
            IPhysicsBalancerCalculator physicsBalancerCalculator = new PhysicsBalancerCalculator(physicsBalancerSettings.Force);

            IPhysicsBalancer balancer = new PhysicsBalancer(physicsBody, physicsBalancerCalculator, physicsBalancerSettings.Target);
            _balancers[limb] = balancer;
        }
    }
    public void OnFixedFrame()
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
