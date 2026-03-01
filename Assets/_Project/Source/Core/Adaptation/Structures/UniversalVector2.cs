public readonly struct UniversalVector2
{
	private readonly float _x;
	private readonly float _y;
	public readonly float X => _x;
	public readonly float Y => _y;
	public UniversalVector2(float x, float y)
	{
		_x = x;
		_y = y;
	}
    public static UniversalVector2 Zero => new(0f, 0f);
	public static UniversalVector2 One => new(1f, 1f);
	public static UniversalVector2 Up => new(0f, 1f);
	public static UniversalVector2 Down => new(0f, -1f);
	public static UniversalVector2 Right => new(1f, 0f);
	public static UniversalVector2 Left => new(-1f, 0f);
    public float SqrLength => X * X + Y * Y;
    public float Length => UniversalMath.Sqrt(SqrLength);
	public float Angle => UniversalMath.Atan2(Y, X) * UniversalMath.Rad2Deg;
    public UniversalVector2 Normalized => this / Length;
	public static UniversalVector2 operator +(UniversalVector2 a, UniversalVector2 b) => new(a.X + b.X, a.Y + b.Y);
	public static UniversalVector2 operator -(UniversalVector2 a, UniversalVector2 b) => new(a.X - b.X, a.Y - b.Y);
	public static UniversalVector2 operator *(UniversalVector2 a, UniversalVector2 b) => new(a.X * b.X, a.Y * b.Y);
	public static UniversalVector2 operator /(UniversalVector2 a, UniversalVector2 b) => new(a.X / b.X, a.Y / b.Y);
	public static UniversalVector2 operator -(UniversalVector2 a) => new(-a.X, -a.Y);
	public static UniversalVector2 operator *(UniversalVector2 a, float f) => new(a.X * f, a.Y * f);
	public static UniversalVector2 operator *(float f, UniversalVector2 a) => a * f;
	public static UniversalVector2 operator /(UniversalVector2 a, float f) => new(a.X / f, a.Y / f);
	public static bool operator ==(UniversalVector2 a, UniversalVector2 b) => a.X == b.X && a.Y == b.Y;
	public static bool operator !=(UniversalVector2 a, UniversalVector2 b) => !(a == b);
    public override bool Equals(object obj) => (obj is UniversalVector2 other) && this == other;
    public override int GetHashCode() => System.HashCode.Combine(X, Y);
    public static float Distance(UniversalVector2 a, UniversalVector2 b) => (a - b).Length;
	public static UniversalVector2 Lerp(UniversalVector2 a, UniversalVector2 b, float t) => a + (b - a) * UniversalMath.Clamp01(t);
    public static UniversalVector2 DirectionTo(UniversalVector2 from, UniversalVector2 to) => (to - from).Normalized;
    public static UniversalVector2 GetVectorByCoordinates(float x, float y) => new(x, y);
	public static UniversalVector2 GetVectorByAngle(float angle, float length = 1f) => Rotate(Right * length, angle);
	public static UniversalVector2 Rotate(UniversalVector2 v, float angle)
	{
        float rad = UniversalMath.Deg2Rad * angle;

        float sin = UniversalMath.Sin(rad);
        float cos = UniversalMath.Cos(rad);

        float x = v.X;
        float y = v.Y;

        return new(x * cos - y * sin, x * sin + y * cos);
    }
}
