using IceFebruary.Space;

namespace IceFebruary
{
    public interface IObjectManager : IBaseEntity
    {
        IGameObject Create(IGameObject gameObject);
        IGameObject Create(IGameObject gameObject, Vector2 position);
        IGameObject Create(IGameObject gameObject, Vector2 position, Rotor2 rotation);
    }
}
