namespace UnityIceFebruary.Adaptation
{
    using IceFebruary;
    using IceFebruary.Physics;
    using IceFebruary.Space;
    using IceRaycastHit2D = IceFebruary.Physics.RaycastHit2D;
    using UnityRaycastHit2D = UnityEngine.RaycastHit2D;

    public static class UnityRaycastHit2DConverter
    {
        public static IceRaycastHit2D ToIce(UnityRaycastHit2D raycastHit2D)
        {
            IGameObject gameObject = UnityMethods.Upsert<UnityEngine.GameObject, IGameObject>(raycastHit2D.collider.gameObject);
            ICollider2D collider2D = UnityMethods.Upsert<UnityEngine.Collider2D, ICollider2D>(raycastHit2D.collider);
            ITransform transform = gameObject.Transform;
            Vector2 point = raycastHit2D.point.ToIce();
            float distance = raycastHit2D.distance;

            return new(collider2D, transform, point, distance);
        }
    }
}
