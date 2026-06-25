using IceFebruary.Proxy;

public readonly struct StickmanAssemble
{
	public RagdollSchema RagdollSchema { get; private init; }
    public GroundDetectionSettings GroundDetectionSettings { get; private init; }
	public MovementSettings MovementSettings { get; private init; }
	public PickUpSettings PickUpSettings { get; private init; }
    [Proxy]
	public StickmanAssemble(RagdollSchema ragdollSchema, GroundDetectionSettings groundDetectionSettings, MovementSettings movementSettings, PickUpSettings pickUpSettings)
	{
		RagdollSchema = ragdollSchema;
		GroundDetectionSettings = groundDetectionSettings;
		MovementSettings = movementSettings;
		PickUpSettings = pickUpSettings;
	}
}
