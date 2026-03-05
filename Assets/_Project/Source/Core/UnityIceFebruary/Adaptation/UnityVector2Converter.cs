namespace UnityIceFebruary.Adaptation
{
    using IceFebruary.Space;
    using UnityEngine;

    public static class UnityVector2Converter
    {
        public static IceFebruary.Space.Vector2 ToUniversal(this Vector3 v) => new(v.x, v.y);
        public static IceFebruary.Space.Vector2 ToUniversal(this UnityEngine.Vector2 v) => new(v.x, v.y);
        public static UnityEngine.Vector2 ToUnity2D(this IceFebruary.Space.Vector2 v) => new(v.X, v.Y);
        public static Vector3 ToUnity3D(this IceFebruary.Space.Vector2 v) => new(v.X, v.Y, 0f);
    }
}
