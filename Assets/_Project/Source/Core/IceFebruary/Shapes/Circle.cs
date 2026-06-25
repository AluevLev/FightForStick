namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;

    public sealed record Circle : IShape
    {
        public float Radius { get; private init; }

        [FieldProxy]
        public Circle(float radius)
        {
            Radius = Math.Abs(radius);
        }
    }
}
