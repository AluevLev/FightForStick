namespace IceFebruary.Physics
{
    public readonly struct LayerMask
    {
        public int Mask { get; init; }
        public LayerMask(int mask)
        {
            Mask = mask;
        }
        public static implicit operator LayerMask(int mask) => new(mask);
    }
}
