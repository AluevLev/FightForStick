using IceFebruary;
using IceFebruary.Space;

public class ObjectPool
{
    private readonly IGameObject _prefab;
    private readonly int _poolSize;
    private readonly IGameObject[] _pool;
    private int _currentIndex;
    public ObjectPool(IGameObject prefab, int poolSize)
    {
        _poolSize = poolSize;
        _pool = new IGameObject[poolSize];
        _prefab = prefab;

        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
            _pool[objectInPoolIndex] = InstantiateObjectInPool();
    }
    public IGameObject InstantiateObjectInPool()
    {
        //TODO aaa
        IGameObject objectInPool = null;//Object.Instantiate(_prefab);

        objectInPool.Enabled = false;

        return objectInPool;
    }
    public void Spawn(Vector2 position/*, Quaternion rotation*/)
    {
        IGameObject spawnObject = null;

        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
        {
            IGameObject objectInPool = _pool[objectInPoolIndex];

            if (objectInPool == null)
            {
                objectInPool = InstantiateObjectInPool();
                _pool[objectInPoolIndex] = objectInPool;
            }

            if (!objectInPool.Enabled)
            {
                spawnObject = objectInPool;
                break;
            }
        }

        if (spawnObject == null)
        {
            spawnObject = _pool[_currentIndex];
            _currentIndex = (_currentIndex + 1) % _poolSize;
        }

        spawnObject.Enabled = false;
        spawnObject.Transform.Position = position;
        spawnObject.Enabled = true;
    }
}
