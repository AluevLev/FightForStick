namespace UnityIceFebruary.Adaptation
{
    using IceVector2 = IceFebruary.Space.Vector2;
    using UnityVector2 = UnityEngine.Vector2;

    public static class UnityVector2Converter
    {
        public static IceVector2 ToIce(this UnityVector2 v) => new(v.x, v.y);
        public static UnityVector2 ToUnity(this IceVector2 v) => new(v.X, v.Y);
    }
}
