using IceFebruary;
using IceFebruary.Collections;
using IceFebruary.Physics;
using IceFebruary.Space;
using IceFebruary.Space.Follow;
using IceFebruary.Space.Rotor2Provider;

public sealed class EntityMotor : IEntityMotor
{
    private readonly IRigidbody2D _pushBody;
    private readonly ITargetPossessing<IRotor2Provider> _leftHip;
    private readonly ITargetPossessing<IRotor2Provider> _rightHip;
    private readonly ITargetPossessing<IRotor2Provider>[] _shins;
    private readonly bool _shinsNotExists;

    private readonly IRotor2Provider _limbMinRotation;
    private readonly IRotor2Provider _limbMaxRotation;

    public EntityMotor(IRigidbody2D pushBody, ITargetPossessing<IRotor2Provider> leftHip, ITargetPossessing<IRotor2Provider> rightHip, ITargetPossessing<IRotor2Provider>[] shins, Rotor2 rest, Rotor2 amplitude)
    {
        _pushBody = pushBody;
        _leftHip = leftHip;
        _rightHip = rightHip;
        _shins = shins;
        _shinsNotExists = !shins.Exists();

        _limbMinRotation = new Rotor2Provider(rest * amplitude.Inverse);
        _limbMaxRotation = new Rotor2Provider(rest * amplitude);
    }
    public void OpenHips()
    {
        if (!_leftHip.Exists() || !_rightHip.Exists())
            return;

        _leftHip.SetTarget(_limbMinRotation);
        _rightHip.SetTarget(_limbMaxRotation);
    }
    public void CloseHips()
    {
        if (!_leftHip.Exists() || !_rightHip.Exists())
            return;

        _leftHip.SetTarget(_limbMaxRotation);
        _rightHip.SetTarget(_limbMinRotation);
    }
    private void SetShins(IRotor2Provider rotation)
    {
        if (_shinsNotExists)
            return;

        for (int index = 0; index < _shins.Length; index++)
        {
            ITargetPossessing<IRotor2Provider> shin = _shins[index];

            if (shin.Exists())
                shin.SetTarget(rotation);
        }
    }
    public void SetMinShins() => SetShins(_limbMinRotation);
    public void SetMaxShins() => SetShins(_limbMaxRotation);
    public void ResetLegs()
    {
        if (_leftHip.Exists())
            _leftHip.ResetTarget();
        if (_rightHip.Exists())
            _rightHip.ResetTarget();

        if (_shinsNotExists)
            return;

        for (int index = 0; index < _shins.Length; index++)
        {
            ITargetPossessing<IRotor2Provider> shin = _shins[index];

            if (shin.Exists())
                shin.ResetTarget();
        }
    }
    public void ForcePush(Vector2 force)
    {
        if (_pushBody.Exists())
            _pushBody.AddForce(force, ForceMode2D.Force);
    }
    public void ImpulsePush(Vector2 impulse)
    {
        if (_pushBody.Exists())
            _pushBody.AddForce(impulse, ForceMode2D.Impulse);
    }
}
