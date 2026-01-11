using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private GameInputAction _controls;
    private IMovable _movable;
    private void Awake()
    {
        _controls = new();
        _movable = GetComponent<IMovable>();
    }
    private void OnEnable() => _controls.Player.Enable();
    private void OnDisable() => _controls.Player.Disable();
    private void Update()
    {
        float movementDirection = _controls.Player.Move.ReadValue<float>();
        _movable.SetMovementDirection(movementDirection);

        if (_controls.Player.Jump.WasPressedThisFrame())
            _movable.Jump();
    }
}
