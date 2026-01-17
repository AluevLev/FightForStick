using UnityEngine;

public class NullInputProvider : IInputProvider
{
    public Vector2 MousePosition => Vector2.zero;
    public float HorizontalMovement => 0f;
    public float VerticalMovement => 0f;
    public bool IsDialogueInteract => false;
    public bool IsDroppingItem => false;
    public bool IsAttacking => false;
    public bool IsPickingUp => false;
}
