namespace IceFebruary.Components
{
    using IceFebruary.Space;
    public interface ICamera
    {
        Vector2 ScreenToWorldPoint(Vector2 onScreenPosition);
        Vector2 WorldToScreenPoint(Vector2 inWorldPosition);
    }
}
