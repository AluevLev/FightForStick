namespace IceFebruary.Physics
{
    public readonly struct LayerMask
    {
        public int Mask { get; private init; }
        public LayerMask(int mask)
        {
            Mask = mask;
        }
    }
}
