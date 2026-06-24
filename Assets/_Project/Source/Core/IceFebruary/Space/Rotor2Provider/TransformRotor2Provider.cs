namespace IceFebruary.Space.Rotor2Provider
{
    using IceFebruary.Proxy;

    public sealed class TransformRotor2Provider : IRotor2Provider
    {
        private readonly ITransform _transform;
        [FieldProxy(typeof(IRotor2Provider))]
        public TransformRotor2Provider(ITransform transform)
        {
            _transform = transform;
        }
        public bool TryGet(out Rotor2 angle)
        {
            bool success = _transform.Exists();

            angle = success ? _transform.Rotation : default;

            return success;
        }
    }
}
