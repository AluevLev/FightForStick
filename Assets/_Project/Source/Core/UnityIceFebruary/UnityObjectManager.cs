namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public UnityObjectManager() { }
        public IGameObject Create(IGameObject gameObject, Vector2? position = null, Rotor2? rotation = null) =>
            gameObject is UnityGameObject unityGameObject ?
            (IGameObject)UnityMethods.Upsert(UnityEngine.Object.Instantiate(
                unityGameObject.Original, 
                (position.HasValue ? position.Value : Vector2.Far).ToUnity(), 
                (rotation.HasValue ? rotation.Value : Rotor2.Default).ToUnity())) : null;
    }
}
