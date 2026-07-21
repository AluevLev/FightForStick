namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public UnityObjectManager() { }
        public IGameObject Create(IGameObject gameObject) => Create(gameObject, gameObject.Transform.Position, Rotor2.Default);
        public IGameObject Create(IGameObject gameObject, Vector2 position) => Create(gameObject, position, Rotor2.Default);
        public IGameObject Create(IGameObject gameObject, Vector2 position, Rotor2 rotation) => gameObject is UnityGameObject unityGameObject ? (IGameObject)UnityMethods.Upsert(UnityEngine.Object.Instantiate(unityGameObject.Original, position.ToUnity(), rotation.ToUnity())) : null;
    }
}
