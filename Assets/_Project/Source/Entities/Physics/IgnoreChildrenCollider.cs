using UnityEngine;

public class IgnoreChildrenCollider : MonoBehaviour
{
    private void Start()
    {
        Collider2D[] colliders2D = GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < colliders2D.Length; i++)
        {
            for (int j = i + 1; j < colliders2D.Length; j++)
            {
                Physics2D.IgnoreCollision(colliders2D[i], colliders2D[j]);
            }
        }
    }
}
