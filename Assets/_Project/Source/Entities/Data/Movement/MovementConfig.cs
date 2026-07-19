using IceFebruary.Physics;
using IceFebruary.Proxy;

public readonly struct MovementConfig
{
	public IRigidbody2D PushBody { get; private init; }
    public IPhysicsBalancer Hip1 { get; private init; }
    public IPhysicsBalancer Hip2 { get; private init; }
    public IPhysicsBalancer[] Shins { get; private init; }
    public MovementSettings Settings { get; private init; }
    public AreaScannerConfig GroundAreaScannerConfig { get; private init; }

    [FieldProxy]
	public MovementConfig(IRigidbody2D pushBody,
		IPhysicsBalancer hip1, IPhysicsBalancer hip2, IPhysicsBalancer[] shins,
		MovementSettings settings, AreaScannerConfig groundAreaScannerConfig)
	{
		PushBody = pushBody;
		Hip1 = hip1;
		Hip2 = hip2;
		Shins = shins;
		Settings = settings;
		GroundAreaScannerConfig = groundAreaScannerConfig;
	}
}
