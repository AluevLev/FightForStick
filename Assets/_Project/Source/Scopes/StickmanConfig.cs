using IceFebruary.Proxy;

public readonly struct StickmanConfig
{
	public RagdollSchema RagdollSchema { get; private init; }
    public GroundDetectionSettings GroundDetectionSettings { get; private init; }
	public MovementSettings MovementSettings { get; private init; }
	public PickUpSettings PickUpSettings { get; private init; }
    [Proxy]
	public StickmanConfig(RagdollSchema ragdollSchema, GroundDetectionSettings groundDetectionSettings, MovementSettings movementSettings, PickUpSettings pickUpSettings)
	{
		RagdollSchema = ragdollSchema;
		GroundDetectionSettings = groundDetectionSettings;
		MovementSettings = movementSettings;
		PickUpSettings = pickUpSettings;
	}
}
