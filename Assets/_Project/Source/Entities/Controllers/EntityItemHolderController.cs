using IceFebruary;
using IceFebruary.Time;

public sealed class EntityItemHolderController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IItemHolderHandler _holderHandler;
    public EntityItemHolderController(IInputProvider inputProvider, IItemHolderHandler holderHandler)
    {
        _inputProvider = inputProvider;
        _holderHandler = holderHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (!Enabled || !_inputProvider.Exists())
            return;
        if (_inputProvider.IsPickingUpItem)
            _holderHandler.PickUp();
        if (_inputProvider.IsUsing)
            _holderHandler.Use();
        else
            _holderHandler.Release();
        if (_inputProvider.IsDroppingItem)
            _holderHandler.Drop();
    }
}
