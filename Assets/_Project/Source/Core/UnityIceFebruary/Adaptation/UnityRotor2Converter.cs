namespace UnityIceFebruary.Adaptation
{
    using IceFebruary.Space;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public static class UnityRotor2Converter
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rotor2 ToIce(this Quaternion q) => new(q.w, q.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Quaternion ToUnity(this Rotor2 r) => new(0, 0, r.XY, r.Scalar);
    }
}
