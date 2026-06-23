using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Space.PointProvider;
using IceFebruary.Time;

public sealed class PlayerItemHolderController : BaseEntity, IFrame
{
    private readonly IInputProvider _inputProvider;
    private readonly IProvider<Vector2> _cursor;
    private readonly IItemHolderHandler _playerHolderHandler;
    public PlayerItemHolderController(IInputProvider inputProvider, IProvider<Vector2> cursor, IItemHolderHandler playerHolderHandler) : base()
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
