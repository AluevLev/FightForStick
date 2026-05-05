namespace IceFebruary.Physics
{
    public readonly struct ContactFilter2D
    {
        public bool UseTriggers { get; private init; }
        public LayerMask? LayerMask { get; private init; }
        public ContactFilter2D(bool useTriggers = true, LayerMask? layerMask = null)
        {
            UseTriggers = useTriggers;
            LayerMask = layerMask;
        }
        public static readonly ContactFilter2D Default = new(true, null);
    }
}
