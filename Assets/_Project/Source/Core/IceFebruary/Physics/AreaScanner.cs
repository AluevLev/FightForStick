namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;
    using IceFebruary.Space.AngleProvider;
    using IceFebruary.Space.PointProvider;

    public sealed class AreaScanner : BaseEntity, IOverlapper
    {
        private readonly IPhysics2D _physics2D;
        private readonly IShape _shape;
        private readonly IPointProvider _position;
        private readonly IAngleProvider _angleDirection;
        private readonly ContactFilter2D _contactFilter2D;
        public AreaScanner(IPhysics2D physics2D, IShape shape, IPointProvider position = null, IAngleProvider angleDirection = null, ContactFilter2D contactFilter = default)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _angleDirection = angleDirection;
            _contactFilter2D = contactFilter;
        }
        public bool Overlap(Component<ICollider2D>[] colliders2D)
        {
            if (!_position.TryGetPointSafe(out Vector2 position) || !_angleDirection.TryGetAngleSafe(out Rotor2 angleDirection))
            {
                colliders2D = null;
                return false;
            }

            int count = _physics2D.Overlap(_shape, position, angleDirection, _contactFilter2D, colliders2D);

            return count > 0;
        }
    }
}
