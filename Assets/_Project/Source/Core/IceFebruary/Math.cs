namespace IceFebruary
{
    using SysMathF = System.MathF;

    public static class Math
    {
        public const float Pi = SysMathF.PI;
        public const float Epsilon = 1e-5f;
        public const float Rad2Deg = 180f / Pi;
        public const float Deg2Rad = 1f / Rad2Deg;
        public static float Abs(float x) => SysMathF.Abs(x);
        public static float Sqrt(float x) => SysMathF.Sqrt(x);
        public static float Sin(float x) => SysMathF.Sin(x);
        public static float Cos(float x) => SysMathF.Cos(x);
        public static float Atan2(float y, float x) => SysMathF.Atan2(y, x);
        public static int Clamp(this int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static float Clamp(this float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static T Clamp<T>(this T x, T min, T max) where T : System.IComparable<T>
        {
            if (x.CompareTo(min) < 0)
                return min;
            if (x.CompareTo(max) > 0)
                return max;
            return x;
        }
        public static bool InBounds(this int x, int min, int max) => x >= min && x <= max;
        public static bool InBounds(this float x, float min, float max) => x >= min && x <= max;
        public static bool InBounds<T>(this T x, T min, T max) where T : System.IComparable<T> => x.CompareTo(min) >= 0 && x.CompareTo(max) <= 0;
        public static float Lerp(float x, float y, float interpolation) => x + (y - x) * Clamp01(interpolation);
        public static float LerpAngle(float x, float y, float interpolation)
        {
            float delta = GetOnPeriod(y - x, 360f);

            if (delta > 180)
                delta -= 360;

            return x + delta * Clamp01(interpolation);
        }
        public static float GetOnPeriod(float x, float period) => ((x % period) + period) % x;
        public static float Clamp01(float x) => Clamp(x, 0f, 1f);
        public static T Min<T>(T x, T y) where T : System.IComparable<T> => x.CompareTo(y) < 0 ? x : y;
        public static T Max<T>(T x, T y) where T : System.IComparable<T> => x.CompareTo(y) > 0 ? x : y;
    }
}
