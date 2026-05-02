namespace UnityIceFebruary.Adaptation
{
    using IceFebruary.Space;
    using UnityEngine;

    public static class UnityRotor3Converter
    {
        public static Quaternion ToUnity(this Rotor3 r) => new(r.YZ, r.ZX, r.XY, r.Scalar);
        public static Rotor3 ToIce(this Quaternion q) => new(q.w, q.z, q.x, q.y);
    }
}
