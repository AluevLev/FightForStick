using IceFebruary.Physics;
using IceFebruary;

public interface IPickable : IComponent
{
    IEntireComponent<IHingeJoint2D>[] Holders { get; }
}
