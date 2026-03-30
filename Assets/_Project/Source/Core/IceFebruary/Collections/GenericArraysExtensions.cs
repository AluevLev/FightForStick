namespace IceFebruary.Collections
{
    using IceFebruary.Random;
    using System.Collections.Generic;

    public static class GenericArraysExtensions
    {
        public static bool Exists<T>(this T[] array) => array != null && array.Length > 0;
        public static bool Exists<T>(this List<T> list) => list != null && list.Count > 0;
        public static T GetSafetyElement<T>(this T[] array, int index, Random random = null) => index switch
        {
            EnumeratorsSpecial.Empty => default,
            EnumeratorsSpecial.Random => random == null ? GlobalRandom.InArray(array) : random.InArray(array),
            _ => array.Exists() ? array[Math.Clamp(index, 0, array.Length - 1)] : default
        };
        public static T GetSafetyElement<T>(this List<T> array, int index, Random random = null) => index switch
        {
            EnumeratorsSpecial.Empty => default,
            EnumeratorsSpecial.Random => random == null ? GlobalRandom.InList(array) : random.InList(array),
            _ => array.Exists() ? array[Math.Clamp(index, 0, array.Count - 1)] : default
        };
    }
}
