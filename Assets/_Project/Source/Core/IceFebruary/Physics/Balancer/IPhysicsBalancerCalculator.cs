namespace IceFebruary.Physics.Balancer
{
    using IceFebruary.Space;

    public interface IPhysicsBalancerCalculator
    {
        Rotor2 CalculateAngle(Rotor2 currentRotation, Rotor2 targetAngle);
    }
}
