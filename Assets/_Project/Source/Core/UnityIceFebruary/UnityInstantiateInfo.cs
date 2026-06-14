namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    public abstract class UnityInstantiateInfo<T> : MonoBehaviour, IClassInfo<T> where T : struct
    {
        public abstract T ToPoco();
    }
}
