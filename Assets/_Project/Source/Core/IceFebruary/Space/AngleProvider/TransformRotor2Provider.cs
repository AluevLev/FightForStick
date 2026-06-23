namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class TransformRotor2Provider : IProvider<Rotor2>
    {
        private readonly ITransform _transform;
        [FieldProxy(typeof(IProvider<Rotor2>))]
        public TransformRotor2Provider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGet(out Rotor2 angle)
        {
            bool success = _transform.Exists();

            angle = success ? _transform.Rotation.To2D() : default;

            return success;
        }
    }
}
