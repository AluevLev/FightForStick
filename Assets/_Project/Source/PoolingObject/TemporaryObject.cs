using IceFebruary;
using IceFebruary.Time;

public sealed class TemporaryObject : BaseEntity, IFixedFrame
{
    public IGameObject GameObject { get; private init; }
    private readonly Timer _timer;
    public TemporaryObject(IGameObject gameObject, Timer timer)
    {
        _timer = timer;

        GameObject = gameObject;

        gameObject.Enabled = false;
    }
    public void Start()
    {
        if (!Enabled || !GameObject.Exists())
            return;

        _timer.SetCooldown();

        GameObject.Enabled = true;
    }
    public void OnFixedFrame()
    {
        if (!Enabled || _timer.InCoolDown || !GameObject.Active())
            return;

        GameObject.Enabled = false;
    }
}
