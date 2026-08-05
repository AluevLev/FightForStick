using IceFebruary;
using IceFebruary.Proxy;

public sealed class ItemConfig : IRootConfig
{
	public ItemSettings Settings { get; private init; }

	[Proxy]
	public ItemConfig(ItemSettings settings)
	{
		Settings = settings;
	}
}
