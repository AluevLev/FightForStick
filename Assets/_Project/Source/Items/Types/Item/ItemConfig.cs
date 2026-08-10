using IceFebruary;

public sealed class ItemConfig : IRootConfig
{
    public ItemSettings Settings { get; private init; }

    public ItemConfig(ItemSettings settings)
    {
        Settings = settings;
    }
}
