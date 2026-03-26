namespace UnityIceFebruary.Components
{
    using IceFebruary.Physics;
    using UnityIceFebruary.AutoGeneration;

    using Collider2D = UnityEngine.Collider2D;

    [UnityAnalog(typeof(Collider2D))]
    public class UnityCollider2D : ICollider2D, IUnityAnalog
    {
        public Collider2D Сollider2D { get; private init; }
        public UnityEngine.Component Original { get; private init; }
        public UnityCollider2D(Collider2D collider2D)
        {
            Сollider2D = collider2D;
            Original = collider2D;
        }
        public bool Enabled
        {
            get => Сollider2D.enabled;
            set => Сollider2D.enabled = value;
        }
    }
}
