namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class SpaceRotor2Provider : IProvider<Rotor2>
    {
        private readonly IProvider<Rotor2> _angleProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IProvider<Rotor2>))]
        public SpaceRotor2Provider(IProvider<Rotor2> angleProvider, ITransform space)
        {
            _space = space;
            _angleProvider = angleProvider;
        }
        public bool TryGet(out Rotor2 angle)
        {
            if (_space.Exists() && _angleProvider.TryGetSafety(out Rotor2 startAngle))
            {
                angle = _space.Rotation.To2D().Inverse * startAngle;
                return true;
            }

            angle = default;
            return false;
        }
    }
}
