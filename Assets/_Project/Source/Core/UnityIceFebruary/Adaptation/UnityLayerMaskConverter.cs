namespace UnityIceFebruary.Adaptation
{
    using IceLayerMask = IceFebruary.Physics.LayerMask;
    using UnityLayerMask = UnityEngine.LayerMask;

    public static class UnityLayerMaskConverter
    {
        public static IceLayerMask ToIce(this UnityLayerMask layerMask) => new(layerMask.value);
        public static UnityLayerMask ToUnity(this IceLayerMask layerMask) => layerMask.Mask;
    }
}
