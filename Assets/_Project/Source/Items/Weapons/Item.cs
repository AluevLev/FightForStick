using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : IPickable
{
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public Item(Component<IHingeJoint2D>[] holders)
    {
        Holders = holders;
    }
}
