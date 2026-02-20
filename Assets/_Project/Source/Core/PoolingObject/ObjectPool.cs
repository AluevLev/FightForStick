using UnityEngine;

public class ObjectPool
{
    private readonly GameObject _prefab;
    private readonly int _poolSize;
    private readonly GameObject[] _pool;
    private int _currentIndex;
    public ObjectPool(GameObject prefab, int poolSize)
    {
        _poolSize = poolSize;
        _pool = new GameObject[poolSize];
        _prefab = prefab;

        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
            _pool[objectInPoolIndex] = InstantiateObjectInPool();
    }
    public GameObject InstantiateObjectInPool()
    {
        GameObject objectInPool = Object.Instantiate(_prefab);

        objectInPool.SetActive(false);

        return objectInPool;
    }
    public void Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject spawnObject = null;

        for (int objectInPoolIndex = 0; objectInPoolIndex < _poolSize; objectInPoolIndex++)
        {
            GameObject objectInPool = _pool[objectInPoolIndex];

            if (!objectInPool)
            {
                objectInPool = InstantiateObjectInPool();
                _pool[objectInPoolIndex] = objectInPool;
            }

            if (!objectInPool.activeSelf)
            {
                spawnObject = objectInPool;
                break;
            }
        }

        if (!spawnObject)
        {
            spawnObject = _pool[_currentIndex];
            _currentIndex = (_currentIndex + 1) % _poolSize;
        }

        spawnObject.SetActive(false);
        spawnObject.transform.SetPositionAndRotation(position, rotation);
        spawnObject.SetActive(true);
    }
}
