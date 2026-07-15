using IceFebruary;

public interface IItemHolderHandler : IBaseEntity
{
    IPickable ItemInHand { get; }
    void PickUp();
    void Drop();
}
