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
        public static int Clamp(int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static float Clamp(float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static T Clamp<T>(T x, T min, T max) where T : System.IComparable<T>
        {
            if (x.CompareTo(min) < 0)
                return min;
            if (x.CompareTo(max) > 0)
                return max;
            return x;
        }
        public static float Lerp(float x, float y, float interpolation) => x + (y - x) * Clamp01(interpolation);
        public static float Clamp01(float x) => Clamp(x, 0f, 1f);
        public static T Min<T>(T x, T y) where T : System.IComparable<T> => x.CompareTo(y) < 0 ? x : y;
        public static T Max<T>(T x, T y) where T : System.IComparable<T> => x.CompareTo(y) > 0 ? x : y;
    }
}
