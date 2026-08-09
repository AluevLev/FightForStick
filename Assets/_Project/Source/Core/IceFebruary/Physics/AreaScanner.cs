namespace IceFebruary.Physics
{
    using IceFebruary;
    using IceFebruary.Shapes;
    using IceFebruary.Space.Rotor2Provider;
    using IceFebruary.Space.Vector2Provider;

    public sealed class AreaScanner : BaseEntity, IOverlapper
    {
        private readonly IPhysics2D _physics2D;
        public Component<ICollider2D>[] Colliders2D { get; private init; }
        public int Colliders2DActualLength { get; private set; }
        public bool Success => Colliders2DActualLength > 0;
        private readonly IShape _shape;
        private readonly IVector2Provider _position;
        private readonly IRotor2Provider _rotation;
        private readonly ContactFilter2D _contactFilter2D;
        public AreaScanner(IPhysics2D physics2D, IShape shape, IVector2Provider position, IRotor2Provider rotation, ContactFilter2D contactFilter, int collider2DBufferSize)
        {
            _physics2D = physics2D;
            _shape = shape;
            _position = position;
            _rotation = rotation;
            _contactFilter2D = contactFilter;

            Colliders2D = new Component<ICollider2D>[collider2DBufferSize.ClampForArray()];
        }
        public void Overlap() => Colliders2DActualLength = _physics2D.Overlap(_shape, _position.GetSafety(), _rotation.GetSafety(), _contactFilter2D, Colliders2D);
    }
}
