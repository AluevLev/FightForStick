namespace IceFebruary.Space
{
    using System.Runtime.CompilerServices;

    public readonly struct Rotor2
    {
        public static readonly Rotor2 Default = new(1f, 0f);
        public float Scalar { get; private init; }
        public float XY { get; private init; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Rotor2(float scalar, float xy)
        {
            Scalar = scalar;
            XY = xy;
        }
        public Rotor2(float angle, bool radian)
        {
            float halfAngle = (radian ? angle : angle * Math.Deg2Rad) * 0.5f;

            Scalar = Math.Cos(halfAngle);
            XY = Math.Sin(halfAngle);
        }
        public readonly Rotor2 Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new(Scalar, -XY);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rotor2 operator *(Rotor2 a, Rotor2 b) => new(a.Scalar * b.Scalar - a.XY * b.XY, a.Scalar * b.XY + a.XY * b.Scalar);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Rotor2 r, Vector2 v)
        {
            float cos2A = r.Scalar * r.Scalar - r.XY * r.XY;
            float sin2A = 2f * r.Scalar * r.XY;

            return new(
                v.X * cos2A - v.Y * sin2A,
                v.X * sin2A + v.Y * cos2A
            );
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Rotor2 a, Rotor2 b) =>
            Math.Abs(a.Scalar - b.Scalar) < Math.Epsilon &&
            Math.Abs(a.XY - b.XY) < Math.Epsilon;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Rotor2 a, Rotor2 b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => (obj is Rotor2 other) && this == other;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => System.HashCode.Combine(Scalar, XY);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Rotor2 Lerp(Rotor2 a, Rotor2 b, float interpolation)
        {
            interpolation = Math.Clamp01(interpolation);

            float dot = a.Scalar * b.Scalar + a.XY * b.XY;

            float aScalar = a.Scalar;
            float aXY = a.XY;
            float bScalar = b.Scalar;
            float bXY = b.XY;

            if (dot < 0)
            {
                bScalar = -bScalar;
                bXY = -bXY;
            }

            float resultScalar = Math.Lerp(aScalar, bScalar, interpolation);
            float resultXY = Math.Lerp(aXY, bXY, interpolation);

            float sqrMagnitude = resultScalar * resultScalar + resultXY * resultXY;
            float invMagnitude = 1f / Math.Sqrt(sqrMagnitude);

            return new(resultScalar * invMagnitude, resultXY * invMagnitude);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ToAngle(bool radian) => Math.Atan2(XY, Scalar) * 2f * (radian ? 1f : Math.Rad2Deg);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Rotor3(Rotor2 r) => new(r.Scalar, r.XY, 0, 0);
    }
}