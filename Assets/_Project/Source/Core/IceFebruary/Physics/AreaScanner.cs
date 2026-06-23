namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;

    public sealed class AreaScanner : BaseEntity, IOverlapper
    {
        private readonly IPhysics2D _physics2D;
        private readonly IShape _shape;
        private readonly IProvider<Vector2> _position;
        private readonly IProvider<Rotor2> _angleDirection;
        private readonly ContactFilter2D _contactFilter2D;
        public AreaScanner(IPhysics2D physics2D, IShape shape, IProvider<Vector2> position = null, IProvider<Rotor2> angleDirection = null, ContactFilter2D? contactFilter = null)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _angleDirection = angleDirection;
            _contactFilter2D = contactFilter.HasValue ? contactFilter.Value : ContactFilter2D.Default;
            _contactFilter2D = contactFilter ?? ContactFilter2D.Default;
        }
        public bool Overlap(Component<ICollider2D>[] colliders2D)
        {
            if (!_position.TryGetSafety(out Vector2 position) || !_angleDirection.TryGetSafety(out Rotor2 angleDirection))
            {
                colliders2D = null;
                return false;
            }

            int count = _physics2D.Overlap(_shape, position, angleDirection, _contactFilter2D, colliders2D);

            return count > 0;
        }
    }
}
