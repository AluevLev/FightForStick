using UnityEngine;

public class LocalCollisionFilter : MonoBehaviour
{
    [SerializeField] private Collider2D[] _colliders2D;
    private void Awake()
    {
        for (int i = 0; i < _colliders2D.Length; i++)
        {
            for (int j = i + 1; j < _colliders2D.Length; j++)
            {
                Physics2D.IgnoreCollision(_colliders2D[i], _colliders2D[j]);
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
