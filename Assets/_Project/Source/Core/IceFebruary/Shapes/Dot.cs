namespace IceFebruary.Shapes
{
    using IceFebruary.Proxy;

    public sealed record Dot : IShape
    {
        public static readonly Dot Instance = new();

        [FieldProxy]
        private Dot() { }
    }
}
