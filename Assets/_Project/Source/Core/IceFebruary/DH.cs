namespace IceFebruary
{
    

    public static class DH
    {
        public static bool Get<T>(ref IDestroyable<T> destroyable, out T value) where T : class
        {
            value = null;

            if (destroyable == null)
                return false;

            if (destroyable.RawObject == null || destroyable.IsDestroyed)
            {
                destroyable = null;
                return false;
            }

            value = destroyable.RawObject;
            return true;
        }
    }
}
