using IceFebruary;
using IceFebruary.Animation;

public sealed class Saw : BaseEntity, IPickable, IUsable, IReleasable
{
    public ItemHolder ItemHolder { get; private init; }
    private readonly AnimatorField<bool> _isUsing;
    public Saw(ItemHolder itemHolder, AnimatorField<bool> isUsing)
    {
        ItemHolder = itemHolder;
        _isUsing = isUsing;
    }
    public void Use() => _isUsing.Value = true;
    public void Release() => _isUsing.Value = false;
}
