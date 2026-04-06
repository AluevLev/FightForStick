namespace IceFebruary.Shapes
{
    public sealed record Circle : IShape
    {
        public float Radius { get; private init; }
        public Circle(float radius)
        {
            Radius = Math.Abs(radius);
        }
    }
}
