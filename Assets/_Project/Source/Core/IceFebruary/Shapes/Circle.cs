namespace IceFebruary.Shapes
{
    using IceFebruary.Space;

    public readonly struct Circle : IShape
    {
        private readonly float _radius;
        private readonly Vector2 _pivot;
        public float Radius => _radius;
        public Vector2 Pivot => _pivot;
        public Circle(float radius, Vector2 pivot)
        {
            _radius = radius;
            _pivot = pivot;
        }
    }
}
