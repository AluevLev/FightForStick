namespace IceFebruary.Shapes
{
    using IceFebruary.Space;

    public readonly struct Rectangle : IShape
    {
        private readonly Vector2 _size;
        private readonly Vector2 _pivot;
        public Vector2 Size => _size;
        public Vector2 Pivot => _pivot;
        public Rectangle(Vector2 size, Vector2 pivot)
        {
            _size = size;
            _pivot = pivot;
        }
    }
}
