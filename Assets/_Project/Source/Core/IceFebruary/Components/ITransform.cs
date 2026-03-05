namespace IceFebruary.Components
{
    using IceFebruary.Space;

    public interface ITransform
    {
        Vector2 Position { get; set; }
        Vector2 LocalPosition { get; set; }
        Vector2 TransformDirection(Vector2 vector2);
    }
}
