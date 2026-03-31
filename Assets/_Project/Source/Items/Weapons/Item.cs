using IceFebruary;
using IceFebruary.Physics;

public class Item : IPickable
{
    public IEntireComponent<IHingeJoint2D>[] Holders { get; private init; }
    public Item(IEntireComponent<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
}
