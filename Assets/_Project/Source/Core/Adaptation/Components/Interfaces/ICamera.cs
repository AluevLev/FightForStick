namespace February.Components
{
    using February.Space;
    public interface ICamera
    {
        UniVector2 ScreenToWorldPoint(UniVector2 onScreenPosition);
        UniVector2 WorldToScreenPoint(UniVector2 inWorldPosition);
    }
}
