using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;
using IceFebruary.Time;

public sealed class PlayerItemHolderController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IVector2Provider _cursor;
    private readonly IItemHolderHandler _playerHolderHandler;
    public PlayerItemHolderController(IInputProvider inputProvider, IVector2Provider cursor, IItemHolderHandler playerHolderHandler)
    {
        _inputProvider = inputProvider;
        _cursor = cursor;
        _playerHolderHandler = playerHolderHandler;
    }
    public void OnFrame(float frameLength)
    {
        if (_inputProvider.IsPickingUp && _cursor.TryGetSafety(out Vector2 cursorPoint))
            _playerHolderHandler.PickUp(cursorPoint);
        if (_inputProvider.IsDroppingItem)
            _playerHolderHandler.Drop();
    }
}
