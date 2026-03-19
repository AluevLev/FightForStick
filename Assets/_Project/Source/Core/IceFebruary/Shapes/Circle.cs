namespace IceFebruary.Shapes
{
    public readonly struct Circle : IShape
    {
        public float Radius { get; private init; }
        public Circle(float radius)
        {
            Radius = radius;
        }
    }
}
