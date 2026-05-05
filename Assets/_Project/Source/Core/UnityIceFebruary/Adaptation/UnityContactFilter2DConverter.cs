namespace UnityIceFebruary.Adaptation
{
    using IceContactFilter2D = IceFebruary.Physics.ContactFilter2D;
    using UnityContactFilter2D = UnityEngine.ContactFilter2D;

    public static class UnityContactFilter2DConverter
    {
        public static IceContactFilter2D ToIce(this UnityContactFilter2D filter) => new(filter.useTriggers, filter.useLayerMask ? filter.layerMask.ToIce() : null);
        public static UnityContactFilter2D ToUnity(this IceContactFilter2D filter)
        {
            UnityContactFilter2D contactFilter2D = new();

            bool useLayerMask = filter.LayerMask.HasValue;

            contactFilter2D.NoFilter();
            contactFilter2D.useTriggers = filter.UseTriggers;
            contactFilter2D.useLayerMask = useLayerMask;

            if (useLayerMask)
                contactFilter2D.layerMask = filter.LayerMask.Value.ToUnity();

            return contactFilter2D;
        }
    }
}
