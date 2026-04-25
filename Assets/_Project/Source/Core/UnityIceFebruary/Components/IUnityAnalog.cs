namespace UnityIceFebruary.Components
{
    using UnityEngine;

    public interface IUnityAnalog<T> where T : Object
    {
        T Original { get; }
    }
}
