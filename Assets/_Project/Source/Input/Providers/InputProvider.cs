using UnityEngine;
using VContainer.Unity;

public class InputProvider : IInputProvider, ITickable
{
    private readonly GameInputAction _controls;
    private readonly GameInputAction.PlayerActions _playerActions;
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public bool IsDialogueInteract { get; private set; }
    public bool IsDroppingItem { get; private set; }

    public Vector2 MousePosition { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsPickingUp { get; private set; }
    public InputProvider(GameInputAction controls)
    {
        _controls = controls;
        _playerActions = _controls.Player;
    }
    public void Tick()
    {
        HorizontalMovement = _playerActions.HorizontalMovement.ReadValue<float>();
        VerticalMovement = _playerActions.VerticalMovement.ReadValue<float>();

        MousePosition = _playerActions.LookPositionOnScreen.ReadValue<Vector2>();
        IsAttacking = _playerActions.Attack.IsPressed();

        IsPickingUp = _playerActions.PickUp.WasPressedThisFrame();
        IsDroppingItem = _playerActions.Drop.WasPressedThisFrame();
        IsDialogueInteract = _playerActions.DialogueInteract.WasPressedThisFrame();
    }
}
