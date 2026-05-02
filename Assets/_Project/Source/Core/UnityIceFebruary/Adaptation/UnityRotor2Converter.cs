namespace UnityIceFebruary.Adaptation
{
    using IceFebruary.Space;
    using UnityEngine;

    public static class UnityRotor2Converter
    {
        public static Quaternion ToUnity(this Rotor2 r) => new(0, 0, r.XY, r.Scalar);
    }
}
