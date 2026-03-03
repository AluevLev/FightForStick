namespace February.Components
{
    using February.Space;

    public interface ITransform
    {
        UniVector2 Position { get; set; }
        UniVector2 LocalPosition { get; set; }
        UniVector2 TransformDirection(UniVector2 vector2);
    }
}
