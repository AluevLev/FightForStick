namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public class Rotor2AngleProvider : IAngleProvider
    {
        private readonly Rotor2 _rotor2;
        [FieldProxy(typeof(IAngleProvider))]
        public Rotor2AngleProvider(Rotor2 rotor2)
        {
            _rotor2 = rotor2;
        }
        public bool TryGetAngle(out Rotor2 angle)
        {
            angle = _rotor2;
            return true;
        }
    }
}
