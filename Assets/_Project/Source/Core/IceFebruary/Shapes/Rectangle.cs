namespace IceFebruary.Shapes
{
    using IceFebruary.Space;

    public readonly struct Rectangle : IShape
    {
        public Vector2 Size { get; private init; }
        public Rectangle(Vector2 size)
        {
            Size = size;
        }
    }
}
