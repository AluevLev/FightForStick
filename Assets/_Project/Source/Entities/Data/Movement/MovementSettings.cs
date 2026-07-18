using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct MovementSettings
{
	public IRigidbody2D PushBody { get; private init; }
    public IPhysicsBalancer LeftHip { get; private init; }
    public IPhysicsBalancer RightHip { get; private init; }
    public IPhysicsBalancer[] Shins { get; private init; }
    public MovementStatistick MovementStatisticks { get; private init; }
	[FieldProxy]
	public MovementSettings(IRigidbody2D pushBody, IPhysicsBalancer leftHip, IPhysicsBalancer rightHip, IPhysicsBalancer[] shins, MovementStatistick movementStatisticks)
	{
		PushBody = pushBody;
		LeftHip = leftHip;
		RightHip = rightHip;
		Shins = shins;
		MovementStatisticks = movementStatisticks;
	}
}
