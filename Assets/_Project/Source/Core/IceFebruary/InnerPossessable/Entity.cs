namespace IceFebruary
{
    public sealed class Entity<T> : IInnerPossessable<T>, IInnerEditable<T>, IDestroyable, IToggleable where T : class
    {
        public T RawInner { get; set; }
        public IToggle Toggle { get; private init; }
        public IDestructor Destructor { get; private init; }
        public Entity(T inner, IToggle toggle, IDestructor destructor)
        {
            RawInner = inner;
            Toggle = toggle;
            Destructor = destructor;
        }
    }
    public class Destructor<T> : IDestructor where T : class
    {
        private readonly IInnerEditable<T> _innerEditable;
        public Destructor(IInnerEditable<T> innerEditable)
        {
            _innerEditable = innerEditable;
            Destroyed = _innerEditable.RawInner == null;
        }
        public bool Destroyed { get; private set; }
        public void Destroy()
        {
            if (Destroyed)
                return;

            Destroyed = true;
            _innerEditable.RawInner = null;
        }
    }
    public interface IDestructor
    {
        bool Destroyed { get; }
        void Destroy();
    }
    public interface IInnerEditable<T>
    {
        T RawInner { get; set; }
    }
}
