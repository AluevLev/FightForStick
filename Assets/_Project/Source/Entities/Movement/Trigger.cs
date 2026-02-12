using VContainer.Unity;

public class Trigger : ITogglable, IFixedTickable
{
    public enum State
    {
        Dead,
        Wait,
        Alive
    }
    private State _triggerLife;
    public bool Active { get; private set; }
    public bool Enabled { get; set; }
    public void Charge()
    {
        if (!Enabled)
            return;

        _triggerLife = State.Wait;
    }
    public void FixedTick()
    {
        ProcessLife();
    }
    private void ProcessLife()
    {
        if (!Enabled)
            return;

        if (_triggerLife == State.Alive)
        {
            Active = false;
            _triggerLife = State.Dead;
        }

        if (_triggerLife == State.Wait)
        {
            Active = true;
            _triggerLife = State.Alive;
        }
    }
}
