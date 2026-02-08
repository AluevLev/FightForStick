using VContainer.Unity;

public class PlayerItemHolderController : ITogglable, IController, ITickable
{
    private readonly IInputProvider _inputProvider;
    private readonly IItemHolderHandler _playerHolderHandler;
    public bool Enabled { get; set; }
    public PlayerItemHolderController(IInputProvider inputProvider, IItemHolderHandler playerHolderHandler)
    {
        _inputProvider = inputProvider;
        _playerHolderHandler = playerHolderHandler;
    }
    public void Tick()
    {
        ProcessInput();
    }
    public void ProcessInput()
    {
        if (!Enabled)
            return;

        if (_inputProvider.IsPickingUp)
            _playerHolderHandler.PickUp();
        if (_inputProvider.IsDroppingItem)
            _playerHolderHandler.Drop();
    }
}
