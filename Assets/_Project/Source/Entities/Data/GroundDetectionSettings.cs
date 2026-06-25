using IceFebruary.Proxy;
using IceFebruary.Space.Rotor2Provider;
using IceFebruary.Space.Vector2Provider;

public readonly struct GroundDetectionSettings
{
	public IVector2Provider GroundDetectorPosition { get; private init; }
	public IRotor2Provider GroundDetectorRotation { get; private init; }
	public GroundCheckSettings GroundCheckSettings { get; private init; }
	[FieldProxy]
	public GroundDetectionSettings(IVector2Provider groundDetectorPosition, IRotor2Provider groundDetectorRotation, GroundCheckSettings groundCheckSettings)
	{
		GroundDetectorPosition = groundDetectorPosition;
		GroundDetectorRotation = groundDetectorRotation;
		GroundCheckSettings = groundCheckSettings;
	}
}
