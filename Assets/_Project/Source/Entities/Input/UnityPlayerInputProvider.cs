using IceFebruary;
using IceFebruary.Space;
using IceFebruary.Time;
using UnityIceFebruary.Adaptation;

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
        if (!Enabled || _controls == null)
            return;

        HorizontalMovement = _playerActions.HorizontalMovement.ReadValue<float>();
        VerticalMovement = _playerActions.VerticalMovement.ReadValue<float>();
        MousePosition = _playerActions.LookPositionOnScreen.ReadValue<UnityEngine.Vector2>().ToIce();
        MouseScrolldown = _playerActions.Scroll.ReadValue<UnityEngine.Vector2>().ToIce().Y;

        IsUsing = _playerActions.IsUsing.IsPressed();

        IsPickingUpItem = _playerActions.IsPickingUp.WasPressedThisFrame();
        IsDroppingItem = _playerActions.IsDropping.WasPressedThisFrame();
    }
}
