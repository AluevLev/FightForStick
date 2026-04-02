namespace IceFebruary
{
    public static class EntityHelper
    {
        public static bool TryKill<TEntity>(ref TEntity entity)
            where TEntity : class
        {
            if (entity == null)
                return false;
            entity = null;
            return true;
        }
        public static bool EnsureAlive<TEntity, TInner>(ref TEntity entity, out TInner inner)
            where TEntity : class, IEntity<TInner>
            where TInner : class
        {
            inner = null;

            bool innerExists = entity != null && entity.TryGetInner(out inner);

            if (!innerExists)
                entity = null;

            return innerExists;
        }
    }
}
