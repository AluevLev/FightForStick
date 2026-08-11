using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Time;
using UnityIceFebruary.Adaptation;
using UnityVector2 = UnityEngine.Vector2;

public sealed class UnityPlayerInputProvider : BaseEntity, IInputProvider, IFrame
{
    private readonly GameInputAction _controls;
    private readonly GameInputAction.PlayerActions _playerActions;
    public float HorizontalMovement { get; private set; }
    public float VerticalMovement { get; private set; }
    public Vector2 MousePosition { get; private set; }
    public float MouseScrolldown { get; private set; }

    public bool IsPickingUpItem { get; private set; }
    public bool IsDroppingItem { get; private set; }
    public bool IsUsing { get; private set; }
    public UnityPlayerInputProvider(GameInputAction controls)
    {
        _controls = controls;
        _playerActions = _controls.Player;

        _controls.Enable();
    }
    public void OnFrame(float frameLength)
    {
        if (Enabled && _controls != null)
            SetControls(_playerActions.HorizontalMovement.ReadValue<float>(),
                _playerActions.VerticalMovement.ReadValue<float>(),
                _playerActions.LookPositionOnScreen.ReadValue<UnityVector2>().ToIce(),
                _playerActions.Scroll.ReadValue<UnityVector2>().ToIce().Y,
                _playerActions.IsUsing.IsPressed(),
                _playerActions.IsPickingUp.WasPressedThisFrame(),
                _playerActions.IsDropping.WasPressedThisFrame());
        else
            SetControls(default, default, default, default, default, default, default);
    }
    private void SetControls(float horizontalMovement, float verticalMovement, Vector2 mousePosition, float mouseScrolldown, bool isUsing, bool isPickingUpItem, bool isDroppingItem)
    {
        HorizontalMovement = horizontalMovement;
        VerticalMovement = verticalMovement;
        MousePosition = mousePosition;
        MouseScrolldown = mouseScrolldown;

        IsUsing = isUsing;
        IsPickingUpItem = isPickingUpItem;
        IsDroppingItem = isDroppingItem;
    }
}
