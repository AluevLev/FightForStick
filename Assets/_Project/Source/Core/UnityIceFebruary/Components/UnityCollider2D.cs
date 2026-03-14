namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;

    public class UnityCollider2D : ICollider2D
    {
        private UnityEngine.Collider2D Сollider2D { get; init; }
        public UnityCollider2D(UnityEngine.Collider2D collider2D)
        {
            Сollider2D = collider2D;
        }
        public bool Enabled
        {
            get => Сollider2D.enabled;
            set => Сollider2D.enabled = value;
        }
    }
}
