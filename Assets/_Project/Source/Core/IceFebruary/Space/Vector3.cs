namespace IceFebruary.Space
{
    public readonly struct Vector3
    {
        public float X { get; private init; }
        public float Y { get; private init; }
        public float Z { get; private init;  }
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public static Vector3 Zero => new(0f, 0f, 0f);
        public static Vector3 One => new(1f, 1f, 1f);
        public static Vector3 Up => new(0f, 1f, 0f);
        public static Vector3 Down => new(0f, -1f, 0f);
        public static Vector3 Right => new(1f, 0f, 0f);
        public static Vector3 Left => new(-1f, 0f, 0f);
        public static Vector3 Forward => new(0f, 0f, 1f);
        public static Vector3 Back => new(0f, 0f, -1f);
        public float SqrLength => X * X + Y * Y + Z * Z;
        public float Length => Math.Sqrt(SqrLength);
        public Vector3 Normalized => Normalize(this);
        public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        public static Vector3 operator -(Vector3 a) => new(-a.X, -a.Y, -a.Z);
        public static Vector3 operator *(Vector3 a, float f) => new(a.X * f, a.Y * f, a.Z * f);
        public static Vector3 operator *(float f, Vector3 a) => a * f;
        public static Vector3 operator /(Vector3 a, float f) => new(a.X / f, a.Y / f, a.Z / f);
        public static bool operator ==(Vector3 a, Vector3 b) => Math.Abs(a.X - b.X) < Math.Epsilon && Math.Abs(a.Y - b.Y) < Math.Epsilon && Math.Abs(a.Z - b.Z) < Math.Epsilon;
        public static bool operator !=(Vector3 a, Vector3 b) => !(a == b);
        public override bool Equals(object obj) => (obj is Vector3 other) && this == other;
        public override int GetHashCode() => System.HashCode.Combine(X, Y);
        public static float SqrDistance(Vector3 a, Vector3 b) => (a - b).SqrLength;
        public static float Distance(Vector3 a, Vector3 b) => (a - b).Length;
        public static Vector3 Normalize(Vector3 v)
        {
            float length = v.Length;
            return length < Math.Epsilon ? Zero : v / length;
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => a + (b - a) * Math.Clamp01(t);
        public static Vector3 DirectionTo(Vector3 from, Vector3 to) => (to - from).Normalized;
        public static implicit operator Vector2(Vector3 v) => new(v.X, v.Y);
    }
}
