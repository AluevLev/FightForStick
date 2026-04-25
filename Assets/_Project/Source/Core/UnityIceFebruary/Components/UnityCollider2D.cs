namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using UnityIceFebruary.AutoGeneration;

    using Collider2D = UnityEngine.Collider2D;

    [UnityAnalog(typeof(Collider2D))]
    public sealed class UnityCollider2D : UnityBaseEntity<Collider2D>, ICollider2D
    {
        public UnityCollider2D(Collider2D collider2D) : base(collider2D) { }
    }
}
