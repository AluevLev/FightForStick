namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public IGameObject Create(IGameObject gameObject, Vector3? position = null, Rotor3? rotation = null) =>
            gameObject is UnityGameObject unityGameObject ?
            (IGameObject)UnityMethods.Upsert(UnityEngine.Object.Instantiate(
                unityGameObject.Original, 
                (position.HasValue ? position.Value : Vector3.Far).ToUnity(), 
                (rotation.HasValue ? rotation.Value : Rotor3.Default).ToUnity())) : null;
    }
}
