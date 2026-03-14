namespace IceFebruary
{
    public interface IFullDataComponent<T> where T : IComponent
    {
        T Component { get; init; }
        IGameObject GameObject { get; init; }
        ITransform Transform { get; init; }
    }
}
