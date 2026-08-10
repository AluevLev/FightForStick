using IceFebruary;
using IceFebruary.Animation;

public sealed class SawConfig : IRootConfig
{
    public ItemSettings ItemSettings { get; private init; }
    public AnimatorField<bool> AnimatorField { get; private init; }

    public SawConfig(ItemSettings itemSettings, AnimatorField<bool> animatorField)
    {
        ItemSettings = itemSettings;
        AnimatorField = animatorField;
    }
}
