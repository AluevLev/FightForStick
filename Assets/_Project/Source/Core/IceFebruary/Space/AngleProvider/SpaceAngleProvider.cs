namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class SpaceAngleProvider : IAngleProvider
    {
        private readonly IAngleProvider _angleProvider;
        private readonly ITransform _space;
        [FieldProxy(typeof(IAngleProvider))]
        public SpaceAngleProvider(IAngleProvider angleProvider, ITransform space)
        {
            _space = space;
            _angleProvider = angleProvider;
        }
        public bool TryGetAngle(out Rotor2 angle)
        {
            if (_space.Exists() && _angleProvider.TryGetAngle(out Rotor2 startAngle))
            {
                angle = _space.Rotation.Inverse * startAngle;
                return true;
            }

            angle = default;
            return false;
        }
    }
}
