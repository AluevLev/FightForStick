namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public UnityObjectManager() { }
        public IGameObject Create(IGameObject gameObject, Vector2 position, Rotor2 rotation) => gameObject is UnityGameObject unityGameObject ? UnityMethods.Upsert<UnityEngine.GameObject, IGameObject>(UnityEngine.Object.Instantiate(unityGameObject.Original, position.ToUnity(), rotation.ToUnity())) : null;
    }
}
