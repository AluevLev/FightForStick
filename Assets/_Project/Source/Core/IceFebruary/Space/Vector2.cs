namespace IceFebruary.Space
{
    public readonly struct Vector2
    {
        public float X { get; private init; }
        public float Y { get; private init; }
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public static Vector2 Zero => new(0f, 0f);
        public static Vector2 One => new(1f, 1f);
        public static Vector2 Up => new(0f, 1f);
        public static Vector2 Down => new(0f, -1f);
        public static Vector2 Right => new(1f, 0f);
        public static Vector2 Left => new(-1f, 0f);
        public float SqrLength => X * X + Y * Y;
        public float Length => Math.Sqrt(SqrLength);
        public float Angle => Math.Atan2(Y, X) * Math.Rad2Deg;
        public Vector2 Normalized => Normalize(this);
        public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new(a.X * b.X, a.Y * b.Y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new(a.X / b.X, a.Y / b.Y);
        public static Vector2 operator -(Vector2 a) => new(-a.X, -a.Y);
        public static Vector2 operator *(Vector2 a, float f) => new(a.X * f, a.Y * f);
        public static Vector2 operator *(float f, Vector2 a) => a * f;
        public static Vector2 operator /(Vector2 a, float f) => new(a.X / f, a.Y / f);
        public static bool operator ==(Vector2 a, Vector2 b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Vector2 a, Vector2 b) => !(a == b);
        public override bool Equals(object obj) => (obj is Vector2 other) && this == other;
        public override int GetHashCode() => System.HashCode.Combine(X, Y);
        public static float Distance(Vector2 a, Vector2 b) => (a - b).Length;
        public static Vector2 Normalize(Vector2 v)
        {
            float length = v.Length;
            return length < Math.Epsilon ? Zero : v / length;
        }
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => a + (b - a) * Math.Clamp01(t);
        public static Vector2 DirectionTo(Vector2 from, Vector2 to) => (to - from).Normalized;
        public static Vector2 GetVectorByCoordinates(float x, float y) => new(x, y);
        public static Vector2 GetVectorByAngle(float angle, float length = 1f) => Rotate(Right * length, angle);
        public static Vector2 Rotate(Vector2 v, float angle)
        {
            float rad = Math.Deg2Rad * angle;

            float sin = Math.Sin(rad);
            float cos = Math.Cos(rad);

            float x = v.X;
            float y = v.Y;

            return new(x * cos - y * sin, x * sin + y * cos);
        }
    }
}
