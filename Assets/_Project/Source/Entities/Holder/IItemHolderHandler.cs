using IceFebruary;

public interface IItemHolderHandler : IBaseEntity
{
    IPickable Item { get; }
    void PickUp();
    void Use();
    void Release();
    void Drop();
}
