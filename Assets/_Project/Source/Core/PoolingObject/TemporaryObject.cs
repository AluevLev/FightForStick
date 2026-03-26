using IceFebruary;

public class TemporaryObject
{
    private readonly IGameObject _gameObject;
    public TemporaryObject(IGameObject gameObject)
    {
        _gameObject = gameObject;
    }
    public void Destroy() => _gameObject.Enabled = false;
}
