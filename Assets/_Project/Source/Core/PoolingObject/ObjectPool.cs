using IceFebruary;
using IceFebruary.Space;


public class ObjectPool
{
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _prefab;
    
    private readonly IToggleable<IGameObject>[] _pool;
    private readonly int _poolSize;

    private int _currentIndex;
    public ObjectPool(IObjectManager objectManager, IGameObject prefab, int poolSize)
    {
        _objectManager = objectManager;
        _prefab = prefab;

        _pool = new IToggleable<IGameObject>[poolSize];
        _poolSize = poolSize;
        
        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
            _pool[objectInPoolIndex] = InstantiateObjectInPool();
    }
    public IToggleable<IGameObject> InstantiateObjectInPool()
    {
        IToggleable<IGameObject> objectInPool = _objectManager.Create(_prefab);

        objectInPool.Enabled = false;

        return objectInPool;
    }
    public void Spawn(Vector2 position)
    {
        IToggleable<IGameObject> spawnObject = null;
        IGameObject innerSpawnObject = null;

        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
        {
            if (H.Get(ref _pool[objectInPoolIndex], out innerSpawnObject, out IToggleable<IGameObject> toggleable))
            {
                spawnObject = toggleable;
                break;
            }

            _pool[objectInPoolIndex] = InstantiateObjectInPool();
        }

        if (spawnObject == null)
        {
            spawnObject = _pool[_currentIndex];
            _currentIndex = (_currentIndex + 1) % _poolSize;
        }

        spawnObject.Enabled = false;
        innerSpawnObject.Transform.Position = position;
        spawnObject.Enabled = true;
    }
}
