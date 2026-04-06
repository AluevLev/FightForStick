using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : IPickable
{
    public IEntireComponent<IHingeJoint2D>[] Holders { get; private init; }
    public Item(IEntireComponent<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
}
