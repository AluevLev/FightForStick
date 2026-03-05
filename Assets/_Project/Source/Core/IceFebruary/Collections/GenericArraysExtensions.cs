namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    public static class GenericArraysExtensions
    {
        public static bool Exist<T>(this T[] array) => array != null && array.Length > 0;
        public static bool Exist<T>(this List<T> list) => list != null && list.Count > 0;
    }
}
