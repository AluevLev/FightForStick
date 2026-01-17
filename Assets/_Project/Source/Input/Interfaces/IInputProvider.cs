using UnityEngine;

public interface IInputProvider
{
    float HorizontalMovement { get; }
    float VerticalMovement { get; }
    bool IsDialogueInteract { get; }
    bool IsDroppingItem { get; }

    Vector2 MousePosition { get; }
    bool IsAttacking { get; }
    bool IsPickingUp { get; }
}
