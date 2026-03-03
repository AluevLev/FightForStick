namespace February.Space
{
    using February.Math;
    public readonly struct UniVector2
    {
        private readonly float _x;
        private readonly float _y;
        public readonly float X => _x;
        public readonly float Y => _y;
        public UniVector2(float x, float y)
        {
            _x = x;
            _y = y;
        }
        public static UniVector2 Zero => new(0f, 0f);
        public static UniVector2 One => new(1f, 1f);
        public static UniVector2 Up => new(0f, 1f);
        public static UniVector2 Down => new(0f, -1f);
        public static UniVector2 Right => new(1f, 0f);
        public static UniVector2 Left => new(-1f, 0f);
        public float SqrLength => X * X + Y * Y;
        public float Length => UniversalMath.Sqrt(SqrLength);
        public float Angle => UniversalMath.Atan2(Y, X) * UniversalMath.Rad2Deg;
        public UniVector2 Normalized => Normalize(this);
        public static UniVector2 operator +(UniVector2 a, UniVector2 b) => new(a.X + b.X, a.Y + b.Y);
        public static UniVector2 operator -(UniVector2 a, UniVector2 b) => new(a.X - b.X, a.Y - b.Y);
        public static UniVector2 operator *(UniVector2 a, UniVector2 b) => new(a.X * b.X, a.Y * b.Y);
        public static UniVector2 operator /(UniVector2 a, UniVector2 b) => new(a.X / b.X, a.Y / b.Y);
        public static UniVector2 operator -(UniVector2 a) => new(-a.X, -a.Y);
        public static UniVector2 operator *(UniVector2 a, float f) => new(a.X * f, a.Y * f);
        public static UniVector2 operator *(float f, UniVector2 a) => a * f;
        public static UniVector2 operator /(UniVector2 a, float f) => new(a.X / f, a.Y / f);
        public static bool operator ==(UniVector2 a, UniVector2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(UniVector2 a, UniVector2 b) => !(a == b);
        public override bool Equals(object obj) => (obj is UniVector2 other) && this == other;
        public override int GetHashCode() => System.HashCode.Combine(X, Y);
        public static float Distance(UniVector2 a, UniVector2 b) => (a - b).Length;
        public static UniVector2 Normalize(UniVector2 v)
        {
            float length = v.Length;
            return length < UniversalMath.Epsilon ? Zero : v / length;
        }
        public static UniVector2 Lerp(UniVector2 a, UniVector2 b, float t) => a + (b - a) * UniversalMath.Clamp01(t);
        public static UniVector2 DirectionTo(UniVector2 from, UniVector2 to) => (to - from).Normalized;
        public static UniVector2 GetVectorByCoordinates(float x, float y) => new(x, y);
        public static UniVector2 GetVectorByAngle(float angle, float length = 1f) => Rotate(Right * length, angle);
        public static UniVector2 Rotate(UniVector2 v, float angle)
        {
            float rad = UniversalMath.Deg2Rad * angle;

            float sin = UniversalMath.Sin(rad);
            float cos = UniversalMath.Cos(rad);

            float x = v.X;
            float y = v.Y;

            return new(x * cos - y * sin, x * sin + y * cos);
        }
    }
}
