namespace UnityIceFebruary.Adaptation
{
    using System.Runtime.CompilerServices;

    using IceVector2 = IceFebruary.Space.Vector2;
    using UnityVector2 = UnityEngine.Vector2;
    using UnityVector3 = UnityEngine.Vector3;

    public static class UnityVector2Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IceVector2 ToIce(this UnityVector2 v) => new(v.x, v.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IceVector2 ToIce(this UnityVector3 v) => new(v.x, v.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnityVector2 ToUnity(this IceVector2 v) => new(v.X, v.Y);
    }
}
