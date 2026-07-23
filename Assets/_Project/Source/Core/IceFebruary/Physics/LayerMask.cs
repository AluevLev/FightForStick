namespace IceFebruary.Physics
{
    using System;
    using System.Runtime.CompilerServices;
    using IceFebruary.Proxy;

    public readonly struct LayerMask : IEquatable<LayerMask>
    {
        public int Mask { get; private init; }

        [FieldProxy]
        public LayerMask(int mask)
        {
            Mask = mask;
        }
        public static readonly LayerMask Default = new(-1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(LayerMask a, LayerMask b) => !(a == b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(LayerMask a, LayerMask b) => a.Mask == b.Mask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(LayerMask layerMask) => this == layerMask;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is LayerMask other && Equals(other);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => HashCode.Combine(Mask);
    }
}
