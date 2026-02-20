public class Trigger : ITogglable
{
    private bool _charged;
    public bool Active { get; private set; }
    public bool Enabled { get; set; } = true;
    public void Charge()
    {
        if (!Enabled)
            return;

        _charged = true;
    }
    public void ProcessLife()
    {
        if (!Enabled)
            _charged = false;

        Active = _charged;
        _charged = false;
    }
}
