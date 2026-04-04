using IceFebruary;
using IceFebruary.Space;


public class ObjectPool
{
    private readonly IObjectManager _objectManager;
    private readonly IGameObject _prefab;
    
    private readonly IEntity<IGameObject>[] _pool;
    private readonly int _poolSize;

    private int _lastObjectIndex;
    public ObjectPool(IObjectManager objectManager, IGameObject prefab, int poolSize)
    {
        _objectManager = objectManager;
        _prefab = prefab;

        _pool = new IEntity<IGameObject>[poolSize];
        _poolSize = poolSize;
        
        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
            _pool[objectInPoolIndex] = InstantiateObjectInPool();

        _lastObjectIndex = _poolSize - 1;
    }
    public IEntity<IGameObject> InstantiateObjectInPool()
    {
        IEntity<IGameObject> objectInPool = _objectManager.Create(_prefab);

        objectInPool.Enabled = false;

        return objectInPool;
    }
    public void Spawn(Vector2 position)
    {
        IEntity<IGameObject> target = null;

        for (int i = 0; i < _poolSize; i++)
        {
            int currentIndex = (_lastObjectIndex + i) % _poolSize;
            IEntity<IGameObject> slot = _pool[currentIndex];

            bool alive = slot.TryGetInner(out _);

            if (!alive)
                slot = InstantiateObjectInPool();

            if (!alive || !slot.Enabled)
            {
                target = slot;
                _lastObjectIndex = (currentIndex + 1) % _poolSize;
                break;
            }
        }

        if (!target.TryGetInner(out IGameObject inner))
            return;

        target = _pool[_lastObjectIndex];
        _lastObjectIndex = (_lastObjectIndex + 1) % _poolSize;

        target.Enabled = false;
        inner.Transform.Position = position;
        target.Enabled = true;
    }
}
