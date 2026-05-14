namespace IceFebruary.Space.AngleProvider
{
    using IceFebruary.Proxy;

    public sealed class TransformAngleProvider : IAngleProvider
    {
        private readonly ITransform2D _transform;
        [FieldProxy(typeof(IAngleProvider))]
        public TransformAngleProvider(ITransform2D transform)
        {
            _transform = transform;
        }
        public bool TryGetAngle(out Rotor2 angle)
        {
            bool success = _transform.Exists();

            angle = success ? _transform.Rotation : default;

            return success;
        }
    }
}
