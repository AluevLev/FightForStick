namespace IceFebruary.Shapes
{
    using IceFebruary.Space;

    public sealed record Rectangle : IShape
    {
        public Vector2 Size { get; private init; }
        public Rectangle(Vector2 size) : this(size.X, size.Y) { }
        public Rectangle(float x, float y)
        {
            Size = new(Math.Abs(x), Math.Abs(y));
        }
    }
}
