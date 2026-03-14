namespace IceFebruary.Shapes
{
    public readonly struct Circle : IShape
    {
        public float Radius { get; init; }
        public Circle(float radius)
        {
            Radius = radius;
        }
    }
}
