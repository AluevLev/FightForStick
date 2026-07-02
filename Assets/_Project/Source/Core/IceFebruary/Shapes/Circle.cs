namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;

    public sealed class Circle : IShape
    {
        public float Radius { get; private init; }

        [FieldProxy(typeof(IShape))]
        public Circle(float radius)
        {
            Radius = Math.Abs(radius);
        }
    }
}
