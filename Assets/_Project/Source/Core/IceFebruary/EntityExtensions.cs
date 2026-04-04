namespace IceFebruary
{
    public static class EntityExtensions
    {
        public static bool TryGetInner<T>(this IEntity<T> entity, out T inner) where T : class
        {
            bool innerExists = entity != null && !entity.Disposed;
            inner = innerExists ? entity.Inner : null;
            return innerExists;
        }
    }
}
