namespace IceFebruary
{
    public static class H
    {
        public static bool EnsureAlive<T>(this IToggleable<T> toggleable) => toggleable != null && toggleable.Alive;
        public static bool Get<T>(ref IToggleable<T> toggleable, out T value, out IToggleable<T> toggleableAsNormal)
        {
            toggleableAsNormal = toggleable;

            if (GetInner(ref toggleable, out T inner) && toggleable.Enabled)
            {
                value = inner;
                return true;
            }

            value = default;
            return false;
        }
        public static bool GetInner<TInnerPossessable, TInner>(ref TInnerPossessable container, out TInner value)
            where TInnerPossessable : class, IInnerPossessable<TInner>
        {
            if (container == null || container.Inner == null)
            {
                container = null;
                value = default;
                return false;
            }

            value = container.Inner;
            return true;
        }
    }
}
