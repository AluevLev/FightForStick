using IceFebruary.Physics;
using IceFebruary.Time;
using IceFebruary;

public sealed class RagdollCore : BaseEntity, IFixedFrame
{
    private readonly IPhysicsBalancer[] _balancers;
    public RagdollCore(PhysicsLimbSettings[] settings) : base()
    {
        _balancers = new IPhysicsBalancer[_balancers.Length];

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
        for (int index = 0; index < _balancers.Length; index++)
            _balancers[index].LookAtTarget();
    }
}
