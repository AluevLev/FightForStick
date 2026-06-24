namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    public sealed class SpaceRotor2Provider : IRotor2Provider
    {
        private readonly IRotor2Provider _angleProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IRotor2Provider))]
        public SpaceRotor2Provider(IRotor2Provider angleProvider, ITransform space)
        {
            _space = space;
            _angleProvider = angleProvider;
        }
        public bool TryGet(out Rotor2 angle)
        {
            if (_space.Exists() && _angleProvider.TryGetSafety(out Rotor2 startAngle))
            {
                angle = _space.Rotation.Inverse * startAngle;
                return true;
            }

            angle = default;
            return false;
        }
    }
}
