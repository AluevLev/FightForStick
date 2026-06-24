namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IRotor2Provider
    {
        bool TryGet(out Rotor2 value);
    }
}
