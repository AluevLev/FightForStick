namespace IceFebruary.Physics
{
    public readonly struct ContactFilter2D
    {
        public bool UseTriggers { get; init; }
        public LayerMask? LayerMask { get; init; }
        public ContactFilter2D(bool useTriggers = true, LayerMask? layerMask = null)
        {
            UseTriggers = useTriggers;
            LayerMask = layerMask;
        }
    }
}
