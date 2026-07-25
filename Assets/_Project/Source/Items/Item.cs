using IceFebruary;
using IceFebruary.Physics;

public sealed class Item : BaseEntity, IPickable
{
    public Component<IHingeJoint2D>[] Holders { get; private init; }
    public IRigidbody2D Rigidbody2D { get; private init; }
    public Item(Component<IHingeJoint2D>[] holders, IRigidbody2D rigidbody2D)
    {
        Holders = holders;
        Rigidbody2D = rigidbody2D;
    }
}
