namespace IceFebruary.Collections
{
    using IceFebruary.Random;
    using System.Collections.Generic;

    public static class GenericArraysExtensions
    {
        public static bool Exists<T>(this T[] array) => array != null && array.Length > 0;
        public static bool Exists<T>(this List<T> list) => list != null && list.Count > 0;
        public static bool TryGetElement<T>(this T[] array, int index, out T element, Random random = null)
        {
            bool elementInArrayExists = array.Exists() && index.InBounds(0, array.Length - 1);

            element = index switch
            {
                EnumeratorsSpecial.Empty => default,
                EnumeratorsSpecial.Random => random == null ? GlobalRandom.InArray(array) : random.InArray(array),
                _ => elementInArrayExists ? array[index] : default
            };

            return elementInArrayExists || index == EnumeratorsSpecial.Empty || index == EnumeratorsSpecial.Random;
        }
        public static bool TryGetElement<T>(this List<T> array, int index, out T element, Random random = null)
        {
            bool elementInListExists = array.Exists() && index.InBounds(0, array.Count - 1);

            element = index switch
            {
                EnumeratorsSpecial.Empty => default,
                EnumeratorsSpecial.Random => random == null ? GlobalRandom.InList(array) : random.InList(array),
                _ => elementInListExists ? array[index] : default
            };

            return elementInListExists || index == EnumeratorsSpecial.Empty || index == EnumeratorsSpecial.Random;
        }
        public static T[] ToStructArray<T>(this T?[] array) where T : struct
        {
            T[] result = new T[array.Length];

            for (int index = 0; index < array.Length; index++)
            {
                T? element = array[index];
                result[index] = element.HasValue ? element.Value : default;
            }
                

            return result;
        }
        public static List<T> ToStructList<T>(this List<T?> list) where T : struct
        {
            List<T> result = new(list.Count);

            for (int index = 0; index < list.Count; index++)
            {
                T? element = list[index];
                result.Insert(index, element.HasValue ? element.Value : default);
            }

            return result;
        }
    }
}
