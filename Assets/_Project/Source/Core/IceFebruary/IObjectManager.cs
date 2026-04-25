namespace IceFebruary
{
    public interface IObjectManager : IBaseEntity
    {
        IGameObject Create(IGameObject gameObject);
    }
}
