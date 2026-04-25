namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public abstract class UnityBaseEntity<T> : BaseEntity, IUnityAnalog<T> where T : UnityEngine.Object
    {
        public T Original { get; private init; }
        public override bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                UnityToggler.Set(Original, _enabled);
            }
        }
        public override void Destroy()
        {
            base.Destroy();

            UnityMethods.Remove(this);
            UnityEngine.Object.Destroy(Original);
        }
        protected UnityBaseEntity(T original, bool? enabled = null)
        {
            Original = original;

            if (enabled.HasValue)
                Enabled = enabled.Value;
            else
                _enabled = UnityToggler.Get(Original);
        }
    }
}
