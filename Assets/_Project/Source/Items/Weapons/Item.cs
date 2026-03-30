using IceFebruary;
using IceFebruary.Physics;
using IceFebruary.Collections;

public class Item : IPickable, ITogglable
{
    public IEntireComponent<IHingeJoint2D>[] Holders { get; private init; }
    public Item(IEntireComponent<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
    public bool IsValid => Holders.Exists();
    public bool Enabled { get; set; } = true;
}
