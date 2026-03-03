namespace February.Space.Follow
{
    using February;
    using February.Space;
    using February.Space.PointProvider;
    using February.Components;

    public class TransformLocalPositionFollower : ITogglable, ITransformFollower
    {
        private readonly IPointProvider _target;
        private readonly ITransform _transform;
        private readonly float _distortion;
        public bool Enabled { get; set; } = true;
        public TransformLocalPositionFollower(ITransform transform, IPointProvider target, float distortion)
        {
            _target = target;
            _transform = transform;
            _distortion = distortion;
        }
        public void Follow()
        {
            if (!Enabled)
                return;
            if (!_target.TryGetPointSafe(out UniVector2 target))
                return;

            _transform.LocalPosition = target * _distortion;
        }
    }
}
