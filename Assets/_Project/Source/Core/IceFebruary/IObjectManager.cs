namespace IceFebruary
{
    public interface IObjectManager
    {
        IGameObject Create(IGameObject gameObject);
        void Destroy(IGameObject gameObject);
        void Destroy(IComponent gameObject);
    }
}
