using IceFebruary.Animation;
using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct MovementSettings
{
	public IRigidbody2D PushBody { get; private init; }
	public AnimatorFloatField MovementFloat { get; private init; }
	public MovementStatistick MovementStatisticks { get; private init; }
	[FieldProxy]
	public MovementSettings(IRigidbody2D pushBody, AnimatorFloatField movementFloat, MovementStatistick movementStatisticks)
	{
		PushBody = pushBody;
		MovementFloat = movementFloat;
		MovementStatisticks = movementStatisticks;
	}
}
