using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Physics;

public readonly struct ItemConfig
{
	public IGameObject GameObject { get; private init; }
	public Component<IHingeJoint2D>[] Holders { get; private init; }
	public PhysicsBalancerConfig PhysicsLimbConfig { get; private init; }

	[Proxy]
	public ItemConfig(IGameObject gameObject, HingeJoint2DComponent[] holders, PhysicsBalancerConfig physicsLimbConfig)
	{
		GameObject = gameObject;

		Holders = new Component<IHingeJoint2D>[holders.Length];

		for (int index = 0; index < holders.Length; index++)
		{
			HingeJoint2DComponent hingeJoint2DComponent = holders[index];
			Holders[index] = new Component<IHingeJoint2D>(hingeJoint2DComponent.HingeJoint2D, hingeJoint2DComponent.GameObject);
        }

		PhysicsLimbConfig = physicsLimbConfig;
	}
}
