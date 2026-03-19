namespace IceFebruary
{
    public interface IEntireComponent<T> where T : IComponent
    {
        T Component { get; }
        IGameObject GameObject { get; }
        ITransform Transform { get; }
    }
}
