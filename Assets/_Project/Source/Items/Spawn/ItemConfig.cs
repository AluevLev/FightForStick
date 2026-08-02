using IceFebruary.Proxy;

public readonly struct ItemConfig
{
	public ItemSettings settings { get; private init; }

	[Proxy]
	public ItemConfig(ItemSettings itemSettings)
	{
		settings = itemSettings;
	}
}
