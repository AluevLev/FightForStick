namespace IceFebruary.Space
{
    using IceFebruary;

    public readonly struct Rotor3
    {
        public static readonly Rotor3 Default = new(1f, 0f, 0f, 0f);
        public float Scalar { get; private init; }
        public float XY { get; private init; }
        public float YZ { get; private init; }
        public float ZX { get; private init; }
        public Rotor3(float scalar, float xy, float yz, float zx)
        {
            Scalar = scalar;
            XY = xy;
            YZ = yz;
            ZX = zx;
        }
        public Rotor3(float xAngle, float yAngle, float zAngle, bool radian)
        {
            float convert = radian ? 1f : Math.Deg2Rad;
            float rx = xAngle * convert;
            float ry = yAngle * convert;
            float rz = zAngle * convert;

            float angle = Math.Sqrt(rx * rx + ry * ry + rz * rz);

            if (angle < Math.Epsilon)
            {
                Scalar = 1f;
                XY = 0f;
                YZ = 0f;
                ZX = 0f;
            }

            else
            {
                float halfAngle = angle * 0.5f;
                Scalar = Math.NimbleCos(halfAngle);
                float s = Math.NimbleSin(halfAngle) / angle;

                XY = rz * s;
                YZ = rx * s;
                ZX = ry * s;
            }
        }
        public readonly Rotor3 Inverse => new(Scalar, -XY, -YZ, -ZX);
        public static Rotor3 operator *(Rotor3 a, Rotor3 b)
        {
            return new(
                a.Scalar * b.Scalar - a.YZ * b.YZ - a.ZX * b.ZX - a.XY * b.XY,
                a.Scalar * b.YZ + a.YZ * b.Scalar + a.ZX * b.XY - a.XY * b.ZX,
                a.Scalar * b.ZX + a.ZX * b.Scalar + a.XY * b.YZ - a.YZ * b.XY,
                a.Scalar * b.XY + a.XY * b.Scalar + a.YZ * b.ZX - a.ZX * b.YZ
            );
        }
        public static Vector3 operator *(Rotor3 r, Vector3 v)
        {
            float qx = r.YZ;
            float qy = r.ZX;
            float qz = r.XY;
            float qw = r.Scalar;

            float tx = 2f * (qy * v.Z - qz * v.Y);
            float ty = 2f * (qz * v.X - qx * v.Z);
            float tz = 2f * (qx * v.Y - qy * v.X);

            return new(
                v.X + qw * tx + (qy * tz - qz * ty),
                v.Y + qw * ty + (qz * tx - qx * tz),
                v.Z + qw * tz + (qx * ty - qy * tx)
            );
        }
        public static bool operator ==(Rotor3 a, Rotor3 b) =>
            Math.Abs(a.Scalar - b.Scalar) < Math.Epsilon &&
            Math.Abs(a.XY - b.XY) < Math.Epsilon &&
            Math.Abs(a.YZ - b.YZ) < Math.Epsilon &&
            Math.Abs(a.ZX - b.ZX) < Math.Epsilon;
        public static bool operator !=(Rotor3 a, Rotor3 b) => !(a == b);
        public override bool Equals(object obj) => (obj is Rotor3 other) && this == other;
        public override int GetHashCode() => System.HashCode.Combine(Scalar, XY);
        public static implicit operator Rotor2(Rotor3 r) => new(r.Scalar, r.XY);
    }
}
