namespace IceFebruary
{
    public interface IComponent<T>
    {
        T Component { get; }
        IGameObject GameObject { get; }
        ITransform Transform { get; }
    }
}
