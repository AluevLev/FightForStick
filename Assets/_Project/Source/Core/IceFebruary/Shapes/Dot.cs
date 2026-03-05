namespace IceFebruary.Shapes
{
    using IceFebruary.Space;

    public readonly struct Dot : IShape
    {
        private readonly Vector2 _pivot;
        public Vector2 Pivot => _pivot;
        public Dot(Vector2 pivot)
        {
            _pivot = pivot;
        }
    }
}
