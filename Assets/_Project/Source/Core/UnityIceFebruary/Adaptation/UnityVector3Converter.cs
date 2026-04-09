namespace UnityIceFebruary.Adaptation
{
    using IceVector3 = IceFebruary.Space.Vector3;
    using UnityVector3 = UnityEngine.Vector3;

    public static class UnityVector3Converter
    {
        public static IceVector3 ToIce(this UnityVector3 v) => new(v.x, v.y, v.z);
        public static UnityVector3 ToUnity(this IceVector3 v) => new(v.X, v.Y, v.Z);
    }
}
