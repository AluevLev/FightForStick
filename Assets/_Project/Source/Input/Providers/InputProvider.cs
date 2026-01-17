using System;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

public class InputProvider : IInputProvider, ILateTickable, IStartable, IDisposable
{
    private readonly GameInputAction _controls;
    private readonly GameInputAction.PlayerActions _playerActions;
    public InputProvider(GameInputAction controls)
    {
        _controls = controls;
        _playerActions = _controls.Player;
    }
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public bool IsDialogueInteract { get; private set; }
    public bool IsDroppingItem { get; private set; }

    public Vector2 MousePosition { get; private set; }
    public bool IsAttacking { get; private set; }
    public bool IsPickingUp { get; private set; }
    public void Start()
    {
        _playerActions.Enable();

        _playerActions.VerticalMovement.performed += OnVerticalChange;
        _playerActions.VerticalMovement.canceled += OnVerticalChange;
        _playerActions.HorizontalMovement.performed += OnHorizontalChange;
        _playerActions.HorizontalMovement.canceled += OnHorizontalChange;

        _playerActions.LookPositionOnScreen.performed += OnMousePositionChange;
        _playerActions.LookPositionOnScreen.canceled += OnMousePositionChange;

        _playerActions.Attack.performed += callbackContext => IsAttacking = true;
        _playerActions.Attack.canceled += callbackContext => IsAttacking = false;

        _playerActions.PickUp.performed += callbackContext => IsPickingUp = true;
        _playerActions.Drop.performed += callbackContext => IsDroppingItem = true;
        _playerActions.DialogueInteract.performed += callbackContext => IsDialogueInteract = true;
    }
    public void Dispose()
    {
        _playerActions.VerticalMovement.performed -= OnVerticalChange;
        _playerActions.VerticalMovement.canceled -= OnVerticalChange;
        _playerActions.HorizontalMovement.performed -= OnHorizontalChange;
        _playerActions.HorizontalMovement.canceled -= OnHorizontalChange;

        _playerActions.LookPositionOnScreen.performed -= OnMousePositionChange;
        _playerActions.LookPositionOnScreen.canceled -= OnMousePositionChange;

        _playerActions.Disable();
    }
    private void OnVerticalChange(InputAction.CallbackContext callbackContext) => VerticalMovement = callbackContext.ReadValue<float>();
    private void OnHorizontalChange(InputAction.CallbackContext callbackContext) => HorizontalMovement = callbackContext.ReadValue<float>();
    private void OnMousePositionChange(InputAction.CallbackContext callbackContext) => MousePosition = callbackContext.ReadValue<Vector2>();
    public void LateTick()
    {
        IsPickingUp = false;
        IsDroppingItem = false;
        IsDialogueInteract = false;
    }
}
