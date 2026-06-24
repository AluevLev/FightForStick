using IceFebruary.Space;

namespace IceFebruary
{
    public interface IObjectManager : IBaseEntity
    {
        IGameObject Create(IGameObject gameObject, Vector2? position = null, Rotor2? rotation = null);
    }
}
