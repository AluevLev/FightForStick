namespace IceFebruary
{
    using IceFebruary.Time;

    public sealed class Trigger : BaseEntity, IFixedFrame
    {
        private bool _charged;
        public bool Active { get; private set; }
        public void Charge() => _charged = true;
        public void OnFixedFrame()
        {
            Active = _charged;
            _charged = false;
        }
    }
}
