using IceFebruary;
using IceFebruary.Animation;

public class Saw : BaseEntity, IPickable, IUsable, IReleasable
{
    public ItemHolder ItemHolder { get; private init; }
    private readonly AnimatorBoolField _isUsing;
    public Saw(ItemHolder itemHolder, AnimatorBoolField isUsing)
    {
        ItemHolder = itemHolder;
        _isUsing = isUsing;
    }
    public void Use() => _isUsing.Value = true;
    public void Release() => _isUsing.Value = false;
}
