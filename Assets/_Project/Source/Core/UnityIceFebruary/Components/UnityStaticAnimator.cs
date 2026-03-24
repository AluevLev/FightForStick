namespace UnityIceFebruary.Components
{
    using System;
    using UnityEngine;

    public static class UnityStaticAnimator<T> where T : struct
    {
        public static readonly Func<Animator, int, T> Get;
        public static readonly Action<Animator, int, T> Set;
        static UnityStaticAnimator()
        {
            if (typeof(T) == typeof(bool))
            {
                Get = (animator, hash) => (T)(object)animator.GetBool(hash);
                Set = (animator, hash, value) => animator.SetBool(hash, (bool)(object)value);
            }
                
            else if (typeof(T) == typeof(int))
            {
                Get = (animator, hash) => (T)(object)animator.GetInteger(hash);
                Set = (animator, hash, value) => animator.SetInteger(hash, (int)(object)value);
            }
            
            else if (typeof(T) == typeof(float))
            {
                Get = (animator, hash) => (T)(object)animator.GetFloat(hash);
                Set = (animator, hash, value) => animator.SetFloat(hash, (float)(object)value);
            }

            else
            {
                Get = (animator, hash) => default;
                Set = (animator, hash, value) => { };
            }
        }
    }
}
