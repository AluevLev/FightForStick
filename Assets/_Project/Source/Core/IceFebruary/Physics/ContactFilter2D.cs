namespace IceFebruary.Physics
{
    using IceFebruary.Proxy;
    using System;
    using System.Runtime.CompilerServices;

    public readonly struct ContactFilter2D : IEquatable<ContactFilter2D>
    {
        public bool UseTriggers { get; private init; }
        public LayerMask LayerMask { get; private init; }

        [FieldProxy]
        public ContactFilter2D(LayerMask layerMask, bool useTriggers = true)
        {
            UseTriggers = useTriggers;
            LayerMask = layerMask;
        }
        public static readonly ContactFilter2D Default = new(LayerMask.Default, true);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(ContactFilter2D a, ContactFilter2D b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(ContactFilter2D a, ContactFilter2D b) =>
            a.UseTriggers == b.UseTriggers &&
            a.LayerMask == b.LayerMask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ContactFilter2D contactFilter2D) => this == contactFilter2D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is ContactFilter2D other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(UseTriggers, LayerMask);
    }
}
