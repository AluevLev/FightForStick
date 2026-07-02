namespace IceFebruary.Shapes
{
    public sealed class Dot : IShape
    {
        public static readonly Dot Instance = new();
        private Dot() { }
    }
}
