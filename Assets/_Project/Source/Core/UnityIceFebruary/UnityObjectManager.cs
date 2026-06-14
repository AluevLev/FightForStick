namespace UnityIceFebruary
{
    using IceFebruary;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public IGameObject Create(IGameObject gameObject) => gameObject is UnityGameObject unityGameObject ? (IGameObject)UnityMethods.Upsert(UnityEngine.Object.Instantiate(unityGameObject.Original)) : null;
    }
}
