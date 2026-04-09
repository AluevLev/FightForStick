using IceFebruary.Physics;
using IceFebruary;

public interface IPickable
{
    IComponent<IHingeJoint2D>[] Holders { get; }
}
