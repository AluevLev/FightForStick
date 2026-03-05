namespace IceFebruary.Random
{
    using System.Collections.Generic;

    /// <summary>
    /// ATTENTION: Recommended for visual use only. This random is difficult to test.
    /// </summary>
    public static class GlobalRandom
    {
        private static readonly Random _random = new(1);
        public static int BetweenInt(int min, int max) => _random.BetweenInt(min, max);
        public static float BetweenFloat(float min, float max) => _random.BetweenFloat(min, max);
        public static bool FiftyFifty => _random.FiftyFifty;
        public static float Percent => _random.Percent;
        public static T InArray<T>(T[] array) => _random.InArray(array);
        public static T InList<T>(List<T> list) => _random.InList(list);
    }
}
