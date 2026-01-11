using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private TemporaryObject _prefab;
    [SerializeField] private int _poolSize;

    private Queue<TemporaryObject> _activeObjects = new();
    private Queue<TemporaryObject> _inactiveObjects = new();
    private void Awake()
    {
        FillPool();
    }
    private void FillPool()
    {
        for (int obj = 0; obj < _poolSize; obj++)
        {
            TemporaryObject temp = Instantiate(_prefab.gameObject).GetComponent<TemporaryObject>();
            temp.Initialize(this);
            temp.gameObject.SetActive(false);
            _inactiveObjects.Enqueue(temp);
        }
    }
    public GameObject Instantiate(Vector2 position, Quaternion rotation)
    {
        TemporaryObject temp = null;

        if (_inactiveObjects.Count > 0)
        {
            temp = _inactiveObjects.Dequeue();
        }

        else
        {
            while (_activeObjects.Count > 0)
            {
                TemporaryObject potentialObject = _activeObjects.Dequeue();

                if (!potentialObject.gameObject.activeSelf)
                    continue;

                temp = potentialObject;
                temp.gameObject.SetActive(false);
                break;
            }
        }

        if (temp)
        {
            _activeObjects.Enqueue(temp);

            temp.transform.SetPositionAndRotation(position, rotation);
            temp.gameObject.SetActive(true);
            temp.StartDestroyCooldown();
        }

        return temp.gameObject;
    }
    public void Destroy(TemporaryObject temp)
    {
        if (!temp.gameObject.activeSelf)
            return;

        temp.gameObject.SetActive(false);
        _inactiveObjects.Enqueue(temp);
    }
}
