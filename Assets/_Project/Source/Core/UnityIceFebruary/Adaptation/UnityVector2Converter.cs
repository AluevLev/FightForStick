namespace UnityIceFebruary.Adaptation
{
    using IceVector2 = IceFebruary.Space.Vector2;
    using UnityVector2 = UnityEngine.Vector2;
    using UnityVector3 = UnityEngine.Vector3;

    public static class UnityVector2Converter
    {
        public static IceVector2 ToIce(this UnityVector3 v) => new(v.x, v.y);
        public static IceVector2 ToIce(this UnityVector2 v) => new(v.x, v.y);
        public static UnityVector2 ToUnity2D(this IceVector2 v) => new(v.X, v.Y);
        public static UnityVector3 ToUnity3D(this IceVector2 v) => new(v.X, v.Y, 0f);
    }
}
