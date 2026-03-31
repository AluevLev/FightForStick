public class PlayerItemHolderController : IController
{
    private readonly IInputProvider _inputProvider;
    private readonly IItemHolderHandler _playerHolderHandler;
    public bool Enabled { get; set; } = true;
    public PlayerItemHolderController(IInputProvider inputProvider, IItemHolderHandler playerHolderHandler)
    {
        _inputProvider = inputProvider;
        _playerHolderHandler = playerHolderHandler;
    }
    public void ProcessInput()
    {
        if (_inputProvider.IsPickingUp)
            _playerHolderHandler.PickUp();
        if (_inputProvider.IsDroppingItem)
            _playerHolderHandler.Drop();
    }
}
