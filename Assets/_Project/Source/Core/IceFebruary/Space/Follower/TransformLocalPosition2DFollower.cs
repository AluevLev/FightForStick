namespace IceFebruary.Space.Follow
{
    using IceFebruary;
    using IceFebruary.Space;
    using IceFebruary.Space.Vector2Provider;

    public sealed class TransformLocalPosition2DFollower : ITransformFollower
    {
        private readonly IVector2Provider _target;
        private readonly ITransform _transform;
        private readonly float _distortion;
        public bool Enabled { get; set; } = true;
        public TransformLocalPosition2DFollower(ITransform transform, IVector2Provider target, float distortion)
        {
            _target = target;
            _transform = transform;
            _distortion = distortion;
        }
        public void Follow()
        {
            if (!_target.TryGetSafety(out Vector2 target))
                return;

            _transform.LocalPosition = (target * _distortion);
        }
    }
}
