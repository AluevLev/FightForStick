using IceFebruary;

public class TemporaryObject
{
    private readonly ITogglable _togglable;
    public TemporaryObject(ITogglable togglable)
    {
        _togglable = togglable;
    }
    public void Destroy() => _togglable.Enabled = false;
}
