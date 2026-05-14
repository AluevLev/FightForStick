using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : BaseEntity, IPickable
{
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public Item(Component<IHingeJoint2D>[] holders) : base()
    {
        Holders = holders;
    }
}
