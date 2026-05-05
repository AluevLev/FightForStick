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
        public static int Sign(float x) => SysMathF.Sign(x);
        public static float Sqrt(float x) => SysMathF.Sqrt(x);
        public static float Sin(float x) => SysMathF.Sin(x);
        public static float Cos(float x) => SysMathF.Cos(x);
        public static float Atan2(float y, float x) => SysMathF.Atan2(y, x);
        public static int GetPower2WithReserve(int x)
        {
            if (x < 2)
                return 0;

            int power = 0;
            int temp = x - 1;

            while (temp > 0)
            {
                temp >>= 1;
                power++;
            }

            return power;
        }
        public static int Clamp(this int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static int ClampMin(this int x, int min) => x < min ? min : x;
        public static int ClampMax(this int x, int max) => x > max ? max : x;
        public static float Clamp(this float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        public static float ClampMin(this float x, float min) => x < min ? min : x;
        public static float ClampMax(this float x, float max) => x > max ? max : x;
        public static bool InBounds(this int x, int min, int max) => x >= min && x <= max;
        public static bool InBounds(this float x, float min, float max) => x >= min && x <= max;
        public static float Lerp(float x, float y, float interpolation) => x + (y - x) * Clamp01(interpolation);
        /*  Rudiment. Tbh idk would i use this. I hope no, but just in case I'll leave this here under the comments
            Pis
        public static float LerpAngle(float x, float y, float interpolation)
        {
            float delta = GetOnPeriod(y - x, 360f);

            if (delta > 180)
                delta -= 360;

            return x + delta * Clamp01(interpolation);
        }
        public static float GetOnPeriod(float x, float period) => ((x % period) + period) % period;
        */
        public static float Clamp01(float x) => Clamp(x, 0f, 1f);
        public static int Min(int x, int y) => x < y ? x : y;
        public static int Max(int x, int y) => x > y ? x : y;
        public static float Min(float x, float y) => x < y ? x : y;
        public static float Max(float x, float y) => x > y ? x : y;
    }
}
