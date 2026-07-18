using UnityEngine;

public sealed class LocalCollisionFilter : MonoBehaviour
{
    [SerializeField] private Collider2D[] _colliders2D;
    private void Awake()
    {
        for (int index = 0; index < _colliders2D.Length; index++)
        {
            for (int jndex = index + 1; jndex < _colliders2D.Length; jndex++)
            {
                Physics2D.IgnoreCollision(_colliders2D[index], _colliders2D[jndex]);
            }
        }

        Destroy(this);
    }
#if UNITY_EDITOR
    [ContextMenu("Bake Colliders")]
    private void Bake()
    {
        _colliders2D = GetComponentsInChildren<Collider2D>(true);
        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif
}
