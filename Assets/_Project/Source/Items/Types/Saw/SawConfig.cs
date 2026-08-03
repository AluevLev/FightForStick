using IceFebruary.Animation;
using IceFebruary.Proxy;

public readonly struct SawConfig
{
	public ItemSettings ItemSettings { get; private init; }
	public AnimatorBoolField AnimatorField { get; private init; }

	[Proxy]
	public SawConfig(ItemSettings itemSettings, AnimatorBoolField animatorField)
	{
		ItemSettings = itemSettings;
		AnimatorField = animatorField;
	}
}
