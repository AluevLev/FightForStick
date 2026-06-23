using IceFebruary.Space;

namespace IceFebruary
{
    public interface IObjectManager : IBaseEntity
    {
        IGameObject Create(IGameObject gameObject, Vector3? position = null, Rotor3? rotation = null);
    }
}
