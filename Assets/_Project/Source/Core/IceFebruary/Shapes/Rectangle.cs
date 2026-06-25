namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    public sealed record Rectangle : IShape
    {
        public Vector2 Size { get; private init; }

        [FieldProxy]
        public Rectangle(Vector2 size)
        {
            Size = size;
        }
    }
}
