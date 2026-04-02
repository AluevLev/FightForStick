namespace IceFebruary
{
    public interface IObjectManager
    {
        IEntity<IGameObject> Create(IGameObject gameObject);
    }
}
