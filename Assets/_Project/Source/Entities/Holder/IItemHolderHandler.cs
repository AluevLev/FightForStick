using IceFebruary;

public interface IItemHolderHandler
{
    IPickable Item { get; }
    void PickUp();
    void Use();
    void Release();
    void Drop();
}
