using IceFebruary.Physics;
using IceFebruary.Time;
using IceFebruary;

public sealed class RagdollCore : IFixedFrame
{
    private readonly IPhysicsBalancer[] _balancers;
    public RagdollCore(PhysicsLimbSettings[] settings)
    {
        _balancers = new IPhysicsBalancer[settings.Length];

        for (int limb = 0; limb < settings.Length; limb++)
        {
            PhysicsLimbSettings physicsBalancer = settings[limb];
            //PhysicsBalancerSettings physicsBalancerSettings = physicsBalancer.BalancerSettings;
            
            //IDestroyable<IRigidbody2D> physicsBody = physicsBalancer.Rigidbody2D;
            //IPhysicsBalancerCalculator physicsBalancerCalculator = new PhysicsBalancerCalculator(physicsBalancerSettings.Force);

            //IPhysicsBalancer balancer = new PhysicsBalancer(physicsBody, physicsBalancerCalculator, physicsBalancerSettings.Target);
            //_balancers[limb] = balancer;
        }
    }
    public void OnFixedFrame()
    {
        foreach (IPhysicsBalancer physicsBalancer in _balancers)
            physicsBalancer.LookAtTarget();
    }
}
