using System.Runtime.CompilerServices;

namespace IceFebruary.Space
{
    public readonly struct Vector3
    {
        public static readonly Vector3 Zero = new(0f, 0f, 0f);
        public static readonly Vector3 One = new(1f, 1f, 1f);
        public static readonly Vector3 Up = new(0f, 1f, 0f);
        public static readonly Vector3 Down = new(0f, -1f, 0f);
        public static readonly Vector3 Right = new(1f, 0f, 0f);
        public static readonly Vector3 Left = new(-1f, 0f, 0f);
        public static readonly Vector3 Forward = new(0f, 0f, 1f);
        public static readonly Vector3 Back = new(0f, 0f, -1f);
        public float X { get; private init; }
        public float Y { get; private init; }
        public float Z { get; private init;  }
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float SqrLength
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => X * X + Y * Y + Z * Z;
        }
        public float Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Math.Sqrt(SqrLength);
        }
        public Vector3 Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Normalize(this);
        }
        public Vector3 InCubeNormalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InCubeNormalize(this);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator +(Vector3 a, Vector3 b) => new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 a, Vector3 b) => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator *(Vector3 a, Vector3 b) => a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator -(Vector3 a) => new(-a.X, -a.Y, -a.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(Vector3 a, float f) => new(a.X * f, a.Y * f, a.Z * f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator *(float f, Vector3 a) => a * f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 operator /(Vector3 a, float f) => new(a.X / f, a.Y / f, a.Z / f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector3 a, Vector3 b) =>
            Math.Abs(a.X - b.X) < Math.Epsilon &&
            Math.Abs(a.Y - b.Y) < Math.Epsilon &&
            Math.Abs(a.Z - b.Z) < Math.Epsilon;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector3 a, Vector3 b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => (obj is Vector3 other) && this == other;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => System.HashCode.Combine(X, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrDistance(Vector3 a, Vector3 b) => (a - b).SqrLength;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vector3 a, Vector3 b) => (a - b).Length;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Normalize(Vector3 v)
        {
            float length = v.Length;
            return length < Math.Epsilon ? Zero : v / length;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 InCubeNormalize(Vector3 v) => new(
            Math.ClampNeg11(v.X),
            Math.ClampNeg11(v.Y),
            Math.ClampNeg11(v.Z));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => a + (b - a) * Math.Clamp01(t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 DirectionTo(Vector3 from, Vector3 to) => (to - from).Normalized;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector2(Vector3 v) => new(v.X, v.Y);
    }
}
