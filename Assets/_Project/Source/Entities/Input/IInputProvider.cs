using IceFebruary;
using IceFebruary.Space;

public interface IInputProvider : IBaseEntity
{
    float HorizontalMovement { get; }
    float VerticalMovement { get; }
    Vector2 MousePosition { get; }
    float MouseScrolldown { get; }

    bool IsPickingUpItem { get; }
    bool IsDroppingItem { get; }
    bool IsUsing { get; }
}
