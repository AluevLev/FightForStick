namespace IceFebruary.Components
{
    public interface IComponent : ITogglable
    {
        IGameObject GameObject { get; }
    }
}
