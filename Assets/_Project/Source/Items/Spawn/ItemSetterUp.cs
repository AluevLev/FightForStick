public sealed class ItemSetterUp : ISettableUp<ItemConfig>
{
    private readonly ISettableUp<ItemSettings, ItemHolder> _holderSettableUp;
    public ItemSetterUp(ISettableUp<ItemSettings, ItemHolder> holderSettableUp)
    {
        _holderSettableUp = holderSettableUp;
    }
    public void SetUp(ItemConfig config) => config.settings.GameObject.MainComponent.Value = new Item(_holderSettableUp.SetUp(config.settings));
}
