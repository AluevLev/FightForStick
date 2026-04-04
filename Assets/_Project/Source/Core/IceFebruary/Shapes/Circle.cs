namespace IceFebruary.Shapes
{
    public class Circle : IShape
    {
        public float Radius { get; private init; }
        public Circle(float radius)
        {
            Radius = radius;
        }
    }
}
