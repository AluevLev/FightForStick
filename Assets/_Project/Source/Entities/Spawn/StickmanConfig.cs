using IceFebruary;
using IceFebruary.Proxy;
using IceFebruary.Space.Vector2Provider;

public sealed class StickmanConfig : IRootConfig
{
    public IVector2Provider StickmanPosition { get; private init; }
    public RagdollConfig RagdollConfig { get; private init; }
    public MovementConfig MovementConfig { get; private init; }
    public PickUpConfig PickUpConfig { get; private init; }

    [Proxy]
    public StickmanConfig(IVector2Provider stickmanPosition, RagdollConfig ragdollConfig, MovementConfig movementConfig, PickUpConfig pickUpConfig)
    {
        StickmanPosition = stickmanPosition;
        RagdollConfig = ragdollConfig;
        MovementConfig = movementConfig;
        PickUpConfig = pickUpConfig;
    }
}
