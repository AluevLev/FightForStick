namespace February.Adaptation
{
    using February.Space;
    using UnityEngine;

    public static class UnityVector2Converter
    {
        public static UniVector2 ToUniversal(this Vector3 v) => new(v.x, v.y);
        public static UniVector2 ToUniversal(this Vector2 v) => new(v.x, v.y);
        public static Vector2 ToUnity2D(this UniVector2 v) => new(v.X, v.Y);
        public static Vector3 ToUnity3D(this UniVector2 v) => new(v.X, v.Y, 0f);
    }
}
