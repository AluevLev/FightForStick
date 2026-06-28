namespace IceFebruary.Shapes
{
    public sealed record Dot : IShape
    {
        public static readonly Dot Instance = new();
        private Dot() { }
    }
}
