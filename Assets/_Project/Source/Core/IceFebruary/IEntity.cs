namespace IceFebruary
{
    using System;

    public interface IEntity<out T> : IDisposable where T : class
    {
        T Inner { get; }
        bool Enabled { get; set; }
        bool Disposed { get; }
    }
}
