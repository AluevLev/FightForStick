namespace IceFebruary
{
    public static class InnerPossessableExtensions
    {
        public static bool TryGetInner<T>(this Entity<T> entity, out T inner) where T : class
        {
            bool innerExists = entity != null && !entity.Destructor.Destroyed;
            inner = innerExists ? entity.RawInner : null;
            return innerExists;
        }
    }
}
