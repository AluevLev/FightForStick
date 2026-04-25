using IceFebruary.Physics;
using IceFebruary;

public interface IPickable
{
    Component<IHingeJoint2D>[] Holders { get; }
}
