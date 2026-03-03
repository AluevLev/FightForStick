namespace February.Math
{
    using System;
    public static class UniversalMath
    {
        public const float Pi = MathF.PI;
        public const float Epsilon = 1e-10f;
        public const float Rad2Deg = 180f / Pi;
        public const float Deg2Rad = 1f / Rad2Deg;
        public static float Abs(float x) => MathF.Abs(x);
        public static float Sqrt(float x) => MathF.Sqrt(x);
        public static float Sin(float x) => MathF.Sin(x);
        public static float Cos(float x) => MathF.Cos(x);
        public static float Atan2(float y, float x) => MathF.Atan2(y, x);
        public static float Clamp(float x, float min, float max) => Math.Clamp(x, min, max);
        public static float Clamp01(float x) => Clamp(x, 0f, 1f);
    }
}
