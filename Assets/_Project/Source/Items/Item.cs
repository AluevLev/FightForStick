using IceFebruary;

public sealed class Item : BaseEntity, IPickable
{
    public ItemHolder ItemHolder { get; private init; }
    public Item(ItemHolder itemHolder)
    {
        ItemHolder = itemHolder;
    }
}
