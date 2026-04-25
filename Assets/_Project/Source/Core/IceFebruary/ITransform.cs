namespace IceFebruary
{
    using IceFebruary.Space;

    public interface ITransform : IBaseEntity
    {
        Vector2 Position { get; set; }
        Vector2 LocalPosition { get; set; }
        Vector2 TransformDirection(Vector2 direction);
        Vector2 TransformPoint(Vector2 point);
    }
}
