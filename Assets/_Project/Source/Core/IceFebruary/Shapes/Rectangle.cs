namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;
    using IceFebruary.Space;

    public sealed class Rectangle : IShape
    {
        public Vector2 Size { get; private init; }

        [FieldProxy(typeof(IShape))]
        public Rectangle(Vector2 size)
        {
            Size = size;
        }
    }
}
