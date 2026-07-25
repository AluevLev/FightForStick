using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Physics;

public readonly struct HingeJoint2DComponent
{
	public IGameObject GameObject { get; private init; }
	public IHingeJoint2D HingeJoint2D { get; private init; }

	[FieldProxy]
	public HingeJoint2DComponent(IGameObject gameObject, IHingeJoint2D hingeJoint2D)
	{
		GameObject = gameObject;
		HingeJoint2D = hingeJoint2D;
	}
}
