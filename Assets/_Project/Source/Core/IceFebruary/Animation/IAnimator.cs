namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IAnimator : IBaseEntity
    {
        T Get<T>(int hash) where T : struct;
        void Set<T>(int hash, T value) where T : struct;
        void SetTrigger(int hash);
    }
}
