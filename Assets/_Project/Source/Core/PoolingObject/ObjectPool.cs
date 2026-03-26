using IceFebruary;
using IceFebruary.Space;

public class ObjectPool
{
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _prefab;
    
    private readonly IGameObject[] _pool;
    private readonly int _poolSize;

    private int _currentIndex;
    public ObjectPool(IObjectManager objectManager, IGameObject prefab, int poolSize)
    {
        _objectManager = objectManager;
        _prefab = prefab;

        _pool = new IGameObject[poolSize];
        _poolSize = poolSize;
        
        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
            _pool[objectInPoolIndex] = InstantiateObjectInPool();
    }
    public IGameObject InstantiateObjectInPool()
    {
        IGameObject objectInPool = _objectManager.Create(_prefab);

        objectInPool.Enabled = false;

        return objectInPool;
    }
    public void Spawn(Vector2 position)
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
