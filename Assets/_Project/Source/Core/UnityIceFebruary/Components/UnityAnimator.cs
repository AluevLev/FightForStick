namespace UnityIceFebruary.Components
{
    using UnityIceFebruary;
    using IceFebruary.Animation;
    using IceFebruary.Proxy;

    using Animator = UnityEngine.Animator;

    public sealed class UnityAnimator : UnityBaseEntity<Animator>, IAnimator
    {
        [FieldProxy(typeof(IAnimator))]
        public UnityAnimator(Animator animator) : base(animator) { }
        public int GetInt(int hash) => Original.GetInteger(hash);
        public void SetInt(int hash, int value) => Original.SetInteger(hash, value);
        public float GetFloat(int hash) => Original.GetFloat(hash);
        public void SetFloat(int hash, float value) => Original.SetFloat(hash, value);
        public bool GetBool(int hash) => Original.GetBool(hash);
        public void SetBool(int hash, bool value) => Original.SetBool(hash, value);
        public void SetTrigger(int hash) => Original.SetTrigger(hash);
    }
}
