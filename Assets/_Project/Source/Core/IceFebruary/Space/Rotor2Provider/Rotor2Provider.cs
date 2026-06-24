namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    public sealed class Rotor2Provider : IRotor2Provider
    {
        private readonly Rotor2 _rotor2;
        [FieldProxy(typeof(IRotor2Provider))]
        public Rotor2Provider(Rotor2 rotor2)
        {
            _rotor2 = rotor2;
        }
        public bool TryGet(out Rotor2 angle)
        {
            angle = _rotor2;
            return true;
        }
    }
}
