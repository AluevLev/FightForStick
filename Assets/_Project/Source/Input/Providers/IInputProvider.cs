using IceFebruary;
using IceFebruary.Space;

public interface IInputProvider : IBaseEntity
{
    float HorizontalMovement { get; }
    float VerticalMovement { get; }
    bool IsDialogueInteract { get; }
    bool IsDroppingItem { get; }

    Vector2 MousePosition { get; }
    bool IsAttacking { get; }
    bool IsPickingUp { get; }
}
