using IceFebruary.Proxy;

public readonly struct ItemConfig
{
	public ItemSettings Settings { get; private init; }

	[Proxy]
	public ItemConfig(ItemSettings settings)
	{
		Settings = settings;
	}
}
