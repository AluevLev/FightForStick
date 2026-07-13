public interface IItemHolderHandler
{
    IPickable ItemInHand { get; }
    void PickUp();
    void Drop();
}
