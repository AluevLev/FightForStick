using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Time;

public sealed class ObjectPool
{
    private readonly ITime _time;
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _prefab;
    private readonly float _objectLifeTime;
    
    private readonly TemporaryObject[] _pool;
    private int _currentObjectIndex;
    public ObjectPool(ITime time, IObjectManager objectManager, IGameObject prefab, int poolSize, float objectLifeTime)
    {
        _time = time;
        _objectManager = objectManager;
        _prefab = prefab;
        _objectLifeTime = objectLifeTime;

        _pool = new TemporaryObject[poolSize];

        for (int index = 0; index < poolSize; index++)
            _pool[index] = CreateObject();
    }
    public TemporaryObject CreateObject()
    {
        IGameObject objectInPool = _objectManager.Create(_prefab, Vector2.Zero, Rotor2.Default);

        return new(objectInPool, new(_time, _objectLifeTime));
    }
    public IGameObject Spawn(Vector2 position) => Spawn(position, Rotor2.Default);
    public IGameObject Spawn(Vector2 position, Rotor2 rotation)
    {
        ref TemporaryObject temp = ref _pool[_currentObjectIndex];

        IGameObject created = temp.GameObject;

        if (!created.Exists())
            temp = CreateObject();

        ITransform transform = created.Transform;

        transform.Position = position;
        transform.Rotation = rotation;

        temp.Start();

        _currentObjectIndex = (_currentObjectIndex + 1) % _pool.Length;

        return created;
    }
}
