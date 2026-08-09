using IceFebruary.Factories;

public sealed class SawSetterUp : ISettableUp<SawConfig>
{
    private readonly ISettableUp<ItemSettings, ItemHolder> _holderSettableUp;
    public SawSetterUp(ISettableUp<ItemSettings, ItemHolder> holderSettableUp)
    {
        _holderSettableUp = holderSettableUp;
    }
    public void SetUp(SawConfig config)
    {
        ItemSettings itemSettings = config.ItemSettings;

        itemSettings.GameObject.MainComponent = new Saw(_holderSettableUp.SetUp(itemSettings), config.AnimatorField);
    }
}
