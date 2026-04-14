namespace IceFebruary
{
    using UnityIceFebruary;
    using UnityIceFebruary.Components;

    public class UnityToggle : IToggle
    {
        private readonly IInnerPossessable<IUnityAnalog> _innerPossessable;
        private bool _enabled;
        public UnityToggle(IInnerPossessable<IUnityAnalog> innerPossessable, bool? enabled)
        {
            _innerPossessable = innerPossessable;

            if (enabled.HasValue)
                Enabled = enabled.Value;
            else
                _enabled = UnityToggler.Get(_innerPossessable.RawInner.Original);
        }
        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                UnityToggler.Set(_innerPossessable.RawInner.Original, _enabled);
            }
        }
    }
}
