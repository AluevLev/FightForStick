using IceFebruary;

public sealed class TemporaryObject
{
    private readonly IBaseEntity _togglable;
    public TemporaryObject(IBaseEntity togglable)
    {
        _togglable = togglable;
    }
    public void Destroy() => _togglable.Enabled = false;
}
