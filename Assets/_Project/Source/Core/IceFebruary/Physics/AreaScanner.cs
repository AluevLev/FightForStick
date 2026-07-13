namespace IceFebruary.Physics
{
    using IceFebruary.Shapes;
    using IceFebruary.Space;
    using IceFebruary.Space.Vector2Provider;
    using IceFebruary.Space.Rotor2Provider;

    public sealed class AreaScanner : BaseEntity, IOverlapper
    {
        public Component<ICollider2D>[] Colliders2D { get; private init; }
        public int Colliders2DActualLength { get; private set; }
        public bool Succes => Colliders2DActualLength > 0;
        private readonly IPhysics2D _physics2D;
        private readonly IShape _shape;
        private readonly IVector2Provider _position;
        private readonly IRotor2Provider _angleDirection;
        private readonly ContactFilter2D _contactFilter2D;
        public AreaScanner(IPhysics2D physics2D, IShape shape, IVector2Provider position, IRotor2Provider angleDirection, ContactFilter2D? contactFilter = null, int collider2DBufferSize = 1)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _angleDirection = angleDirection;
            _contactFilter2D = contactFilter ?? ContactFilter2D.Default;

            Colliders2D = new Component<ICollider2D>[collider2DBufferSize.ClampForArray()];
        }
        public void Overlap()
        {
            if (!_position.TryGetSafety(out Vector2 position) || !_angleDirection.TryGetSafety(out Rotor2 angleDirection))
                return;

            Colliders2DActualLength = _physics2D.Overlap(_shape, position, angleDirection, _contactFilter2D, Colliders2D);
        }
    }
}
