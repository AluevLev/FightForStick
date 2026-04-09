namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;
    using IceFebruary.Space.PointProvider;

    public sealed class AreaScanner : IOverlapper
    {
        private readonly IPhysics2D _physics2D;
        private readonly IShape _shape;
        private readonly IPointProvider _position;
        private readonly IPointProvider _angleDirection;
        private readonly ContactFilter2D _contactFilter2D;
        public AreaScanner(IPhysics2D physics2D, IShape shape, IPointProvider position = null, IPointProvider angleDirection = null, ContactFilter2D contactFilter = default)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _angleDirection = angleDirection;
            _contactFilter2D = contactFilter;
        }
        public bool Overlap(IComponent<ICollider2D>[] colliders2D)
        {
            if (!_position.TryGetPointSafe(out Vector2 position) || !_angleDirection.TryGetPointSafe(out Vector2 angleDirection))
            {
                colliders2D = null;
                return false;
            }

            int count = _physics2D.Overlap(_shape, position, angleDirection.Angle, _contactFilter2D, colliders2D);

            return count > 0;
        }
    }
}
