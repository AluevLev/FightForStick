namespace IceFebruary.Render
{
    using IceFebruary.Space;

    public interface ICamera : IBaseEntity
    {
        Vector2 ScreenToWorldPoint(Vector2 onScreenPosition);
        Vector2 WorldToScreenPoint(Vector2 inWorldPosition);
    }
}
