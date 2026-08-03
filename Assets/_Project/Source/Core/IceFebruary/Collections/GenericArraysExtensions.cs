namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    public static class GenericArraysExtensions
    {
        public static bool Exists<T>(this IReadOnlyCollection<T> collection) => collection != null && collection.Count > 0;
    }
}
