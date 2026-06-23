namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class Rotor2Provider : IProvider<Rotor2>
    {
        private readonly Rotor2 _rotor2;
        [FieldProxy(typeof(IProvider<Rotor2>))]
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
