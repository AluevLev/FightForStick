namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    public abstract class UnityInstantiateInfo<T> : MonoBehaviour, IInstantiateInfo<T> where T : struct
    {
        public abstract T ToPoco();
    }
}
