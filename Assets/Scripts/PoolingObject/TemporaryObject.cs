using System.Collections;
using UnityEngine;

public class TemporaryObject : MonoBehaviour
{
    [SerializeField] private float maxLifetime;
    private WaitForSeconds _hold;
    private ObjectPool _objectPool;
    private Coroutine _destroyCoroutine;
    public void Initialize(ObjectPool pool)
    {
        _objectPool = pool;
        _hold = new WaitForSeconds(maxLifetime);
    }
    public void StartDestroyCooldown()
    {
        if (_destroyCoroutine != null)
            StopCoroutine(_destroyCoroutine);
        _destroyCoroutine = StartCoroutine(DestroyAfterMaxLifetime());
    }
    private IEnumerator DestroyAfterMaxLifetime()
    {
        yield return _hold;
        Destroy();
    }
    public void Destroy()
    {
        _objectPool.Destroy(this);
    }
}
