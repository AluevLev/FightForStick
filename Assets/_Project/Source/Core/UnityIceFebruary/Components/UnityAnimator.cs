namespace UnityIceFebruary.Components
{
    using IceFebruary.Animation;
    using IceFebruary.Proxy;
    using System;
    using System.Runtime.CompilerServices;
    using UnityIceFebruary;
    using Animator = UnityEngine.Animator;

    public sealed class UnityAnimator : UnityBaseEntity<Animator>, IAnimator
    {
        [FieldProxy(typeof(IAnimator))]
        public UnityAnimator(Animator animator) : base(animator) { }
        public T Get<T>(int hash) where T : struct
        {
            Type type = typeof(T);

            if (type == typeof(bool))
            {
                bool value = Original.GetBool(hash);
                return Unsafe.As<bool, T>(ref value);
            }

            if (type == typeof(int))
            {
                int value = Original.GetInteger(hash);
                return Unsafe.As<int, T>(ref value);
            }

            if (type == typeof(float))
            {
                float value = Original.GetFloat(hash);
                return Unsafe.As<float, T>(ref value);
            }

            return default;
        }
        public void Set<T>(int hash, T value) where T : struct
        {
            Type type = typeof(T);

            if (type == typeof(bool))
                Original.SetBool(hash, Unsafe.As<T, bool>(ref value));
            if (type == typeof(int))
                Original.SetInteger(hash, Unsafe.As<T, int>(ref value));
            if (type == typeof(float))
                Original.SetFloat(hash, Unsafe.As<T, float>(ref value));
        }
        public void SetTrigger(int hash) => Original.SetTrigger(hash);
    }
}
