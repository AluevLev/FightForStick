namespace IceFebruary
{
    using System;

    public interface IEntity<out T> : IDisposable where T : class
    {
        T RawInner { get; }
        bool Enabled { get; set; }
        bool Disposed { get; }
    }
}
