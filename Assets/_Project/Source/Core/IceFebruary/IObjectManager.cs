namespace IceFebruary
{
    public interface IObjectManager
    {
        IToggleable<IGameObject> Create(IGameObject gameObject);
    }
}
