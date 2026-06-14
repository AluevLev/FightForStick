namespace IceFebruary.Physics
{
    using IceFebruary.Space;

    public readonly struct RaycastHit2D
    {
        public ICollider2D Collider2D { get; private init; }
        public ITransform Transform { get; private init; }
        public Vector2 Point { get; private init; }
        public float Distance { get; private init; }
        public RaycastHit2D(ICollider2D collider2D, ITransform transform, Vector2 point, float distance)
        {
            Collider2D = collider2D;
            Transform = transform;
            Point = point;
            Distance = distance;
        }
    }
}
