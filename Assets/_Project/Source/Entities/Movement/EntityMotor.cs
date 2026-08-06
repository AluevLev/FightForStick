using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Physics.Balancer;
using IceFebruary.Space;
using IceFebruary.Space.Rotor2Provider;

public sealed class EntityMotor : BaseEntity, IEntityMotor
{
	private readonly IRigidbody2D _pushBody;
    private readonly IPhysicsBalancer _leftHip;
    private readonly IPhysicsBalancer _rightHip;
    private readonly IPhysicsBalancer[] _shins;

    private readonly IRotor2Provider _limbMinRotation;
    private readonly IRotor2Provider _limbMaxRotation;
    
    public EntityMotor(IRigidbody2D pushBody, IPhysicsBalancer leftHip, IPhysicsBalancer rightHip, IPhysicsBalancer[] shins, Rotor2 rest, Rotor2 amplitude)
    {
        _pushBody = pushBody;
        _leftHip = leftHip;
        _rightHip = rightHip;
        _shins = shins;

        _limbMinRotation = new Rotor2Provider(rest * amplitude.Inverse);
        _limbMaxRotation = new Rotor2Provider(rest * amplitude);
    }
    public void OpenHips()
    {
        _leftHip.SetTarget(_limbMinRotation);
        _rightHip.SetTarget(_limbMaxRotation);
    }
    public void CloseHips()
    {
        _leftHip.SetTarget(_limbMaxRotation);
        _rightHip.SetTarget(_limbMinRotation);
    }
    private void SetShins(IRotor2Provider rotation)
    {
        for (int index = 0; index < _shins.Length; index++)
            _shins[index].SetTarget(rotation);
    }
    public void SetMinShins() => SetShins(_limbMinRotation);
    public void SetMaxShins() => SetShins(_limbMaxRotation);
    public void ResetLegs()
    {
        _leftHip.ResetTarget();
        _rightHip.ResetTarget();

        for (int index = 0; index < _shins.Length; index++)
            _shins[index].ResetTarget();
    }
    public void ForcePush(Vector2 force) => _pushBody.AddForce(force, ForceMode2D.Force);
    public void ImpulsePush(Vector2 impulse) => _pushBody.AddForce(impulse, ForceMode2D.Impulse);
}
