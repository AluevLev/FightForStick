using IceFebruary;
using IceFebruary.Physics;

public class Item : IPickable
{
    public Item(IEntireComponent<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
    public IEntireComponent<IHingeJoint2D>[] Holders { get; private init; }
    public bool Enabled { get; set; } = true;
}
