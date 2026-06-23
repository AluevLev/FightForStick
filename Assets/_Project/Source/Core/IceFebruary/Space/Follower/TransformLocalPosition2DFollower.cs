namespace IceFebruary.Space.Follow
{
    using IceFebruary;
    using IceFebruary.Space;

    public sealed class TransformLocalPosition2DFollower : ITransformFollower
    {
        private readonly IProvider<Vector2> _target;
        private readonly ITransform _transform;
        private readonly float _distortion;
        public bool Enabled { get; set; } = true;
        public TransformLocalPosition2DFollower(ITransform transform, IProvider<Vector2> target, float distortion)
        {
            _target = target;
            _transform = transform;
            _distortion = distortion;
        }
        public void Follow()
        {
            if (!_target.TryGetSafety(out Vector2 target))
                return;

            _transform.LocalPosition = (target * _distortion).To3D();
        }
    }
}
