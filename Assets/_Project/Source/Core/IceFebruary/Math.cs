namespace IceFebruary
{
    using System.Runtime.CompilerServices;
    using SysMathF = System.MathF;

    public static class Math
    {
        public const float Pi = SysMathF.PI;
        public const float Epsilon = 0.0001f;
        public const float Rad2Deg = 180f / Pi;
        public const float Deg2Rad = Pi / 180f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float x) => SysMathF.Abs(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(float x) => SysMathF.Sign(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x) => SysMathF.Sqrt(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleSin(float x)
        {
            float rem = x % (2f * Pi);

            if (rem > Pi)
                rem -= 2f * Pi;
            if (rem < -Pi)
                rem += 2f * Pi;

            float absRem = Abs(rem);
            float y = 1.2732395f * rem - 0.4052847f * rem * absRem;
            float absY = Abs(y);

            return 0.225f * (y * absY - y) + y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleCos(float x) => NimbleSin(x + Pi * 0.5f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float NimbleAtan2(float y, float x)
        {
            if (x == 0f && y == 0f)
                return 0f;

            float absX = Abs(x);
            float absY = Abs(y);
            float ratio = absX > absY ? absY / absX : absX / absY;
            float angle = (0.9724f - 0.1919f * ratio * ratio) * ratio;

            if (absY > absX)
                angle = (Pi * 0.5f) - angle;
            if (x < 0f)
                angle = Pi - angle;
            if (y < 0f)
                angle = -angle;

            return angle;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(this int x, int min, int max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMin(this int x, int min) => x < min ? min : x;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMax(this int x, int max) => x > max ? max : x;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampForArray(this int x) => x.ClampMin(1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(this float x, float min, float max)
        {
            if (x < min)
                return min;
            if (x > max)
                return max;
            return x;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMin(this float x, float min) => x < min ? min : x;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMax(this float x, float max) => x > max ? max : x;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Normalize(this int x)
        {
            if (x > 0)
                return 1;
            if (x < 0)
                return -1;
            return 0;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Normalize(this float x)
        {
            if (x > 0f)
                return 1f;
            if (x < 0f)
                return -1f;
            return 0f;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(this int x, int min, int max) => x >= min && x <= max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool InBounds(this float x, float min, float max) => x >= min && x <= max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float x, float y, float interpolation) => x + (y - x) * interpolation.Clamp01();
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp01(this float x) => x.Clamp(0f, 1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampNeg11(this float x) => x.Clamp(-1f, 1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Min(int x, int y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Max(int x, int y) => x > y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float x, float y) => x < y ? x : y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float x, float y) => x > y ? x : y;
    }
}
