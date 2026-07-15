using System.Runtime.CompilerServices;

namespace IceFebruary
{
    public static class BaseEntityExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Exists(this IBaseEntity entity) => !(entity == null || entity.Destroyed);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Active(this IBaseEntity entity) => entity.Exists() && entity.Enabled;
    }
}
