namespace IceFebruary.Space
{
    using IceFebruary.Proxy;
    using System.Runtime.CompilerServices;

    public readonly struct Vector2 : System.IEquatable<Vector2>
    {
        public static readonly Vector2 Zero = default;
        public static readonly Vector2 TopRight = new(1f, 1f);
        public static readonly Vector2 TopLeft = new(-1f, 1f);
        public static readonly Vector2 BottomLeft = new(-1f, -1f);
        public static readonly Vector2 BottomRight = new(1f, -1f);
        public static readonly Vector2 Top = new(0f, 1f);
        public static readonly Vector2 Bottom = new(0f, -1f);
        public static readonly Vector2 Right = new(1f, 0f);
        public static readonly Vector2 Left = new(-1f, 0f);
        public float X { get; private init; }
        public float Y { get; private init; }
        [FieldProxy, MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public float SqrLength
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => X * X + Y * Y;
        }
        public float Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Math.Sqrt(SqrLength);
        }
        public Vector2 Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Normalize(this);
        }
        public Vector2 BoxClamped
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => BoxClamp(this);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 DirectionTo(Vector2 to) => DirectionTo(this, to);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(Vector2 a, float f) => new(a.X * f, a.Y * f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator *(float f, Vector2 a) => a * f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 operator /(Vector2 a, float f) => new(a.X / f, a.Y / f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(Vector2 a, Vector2 b) =>
            Math.Abs(a.X - b.X) < Math.Epsilon &&
            Math.Abs(a.Y - b.Y) < Math.Epsilon;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Vector2 other) => this == other;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is Vector2 other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => System.HashCode.Combine(X, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrDistance(Vector2 a, Vector2 b) => (a - b).SqrLength;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Distance(Vector2 a, Vector2 b) => (a - b).Length;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Normalize(Vector2 v)
        {
            float length = v.Length;
            return length < Math.Epsilon ? Right : v / length;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 BoxClamp(Vector2 v) => new(
            v.X.ClampNeg11(),
            v.Y.ClampNeg11());
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => a + (b - a) * t.Clamp01();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector2 DirectionTo(Vector2 from, Vector2 to) => (to - from).Normalized;
    }
}
