using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : IPickable
{
    public IComponent<IHingeJoint2D>[] Holders { get; private init; }
    public Item(IComponent<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
}
