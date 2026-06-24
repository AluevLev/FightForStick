namespace IceFebruary
{
    public static class BaseEntityExtension
    {
        public static bool Exists(this IBaseEntity entity) => !(entity == null || entity.Destroyed);
        public static bool Active(this IBaseEntity entity) => entity.Exists() && entity.Enabled;
    }
}
