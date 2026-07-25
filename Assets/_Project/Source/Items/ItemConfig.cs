using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Physics;

public readonly struct ItemConfig
{
	public Component<IHingeJoint2D>[] Holders { get; private init; }
	public IRigidbody2D Rigidbody2D { get; private init; }

	[Proxy]
	public ItemConfig(HingeJoint2DComponent[] holders, IRigidbody2D rigidbody2D)
	{
		Holders = new Component<IHingeJoint2D>[holders.Length];

		for (int index = 0; index < holders.Length; index++)
		{
			HingeJoint2DComponent hingeJoint2DComponent = holders[index];
			Holders[index] = new Component<IHingeJoint2D>(hingeJoint2DComponent.HingeJoint2D, hingeJoint2DComponent.GameObject);
        }

		Rigidbody2D = rigidbody2D;
	}
}
