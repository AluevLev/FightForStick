namespace IceFebruary.Physics
{
    using IceFebruary.Space;

    public readonly struct RaycastHit2D
    {
        public ICollider2D Collider2D { get; init; }
        public ITransform Transform { get; init; }
        public Vector2 Point { get; init; }
        public float Distance { get; init; }
        public RaycastHit2D(ICollider2D collider2D, ITransform transform, Vector2 point, float distance)
        {
            Collider2D = collider2D;
            Transform = transform;
            Point = point;
            Distance = distance;
        }
    }
}
