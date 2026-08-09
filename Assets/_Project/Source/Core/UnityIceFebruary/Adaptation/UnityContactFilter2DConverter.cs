namespace UnityIceFebruary.Adaptation
{
    using System.Runtime.CompilerServices;
    using IceContactFilter2D = IceFebruary.Physics.ContactFilter2D;
    using IceLayerMask = IceFebruary.Physics.LayerMask;
    using UnityContactFilter2D = UnityEngine.ContactFilter2D;

    public static class UnityContactFilter2DConverter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IceContactFilter2D ToIce(this UnityContactFilter2D filter) => new(filter.useLayerMask ? filter.layerMask.ToIce() : IceLayerMask.Default, filter.useTriggers);
        public static UnityContactFilter2D ToUnity(this IceContactFilter2D filter)
        {
            UnityContactFilter2D contactFilter2D = new();

            bool useLayerMask = filter.LayerMask != IceLayerMask.Default;

            contactFilter2D.NoFilter();
            contactFilter2D.useTriggers = filter.UseTriggers;
            contactFilter2D.useLayerMask = useLayerMask;

            if (useLayerMask)
                contactFilter2D.layerMask = filter.LayerMask.ToUnity();

            return contactFilter2D;
        }
    }
}
