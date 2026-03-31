namespace IceFebruary
{
    public class Trigger
    {
        private bool _charged;
        public bool Active { get; private set; }
        public void Charge() => _charged = true;
        public void Process()
        {
            Active = _charged;
            _charged = false;
        }
    }
}
