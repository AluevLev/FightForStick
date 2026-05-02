namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IAngleProvider
    {
        bool TryGetAngle(out Rotor2 angle);
    }
}
