using IceFebruary.Factories;

public sealed class ItemSetterUp : ISettableUp<ItemConfig>
{
    private readonly ISettableUp<ItemSettings, ItemHolder> _holderSettableUp;
    public ItemSetterUp(ISettableUp<ItemSettings, ItemHolder> holderSettableUp)
    {
        _holderSettableUp = holderSettableUp;
    }
    public void SetUp(ItemConfig config)
    {
        ItemSettings itemHolder = config.Settings;

        itemHolder.GameObject.MainComponent = new Item(_holderSettableUp.SetUp(itemHolder));
    }
}
