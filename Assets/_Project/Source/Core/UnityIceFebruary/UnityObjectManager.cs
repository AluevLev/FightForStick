namespace UnityIceFebruary
{
    using IceFebruary;

    public sealed class UnityObjectManager : BaseEntity, IObjectManager
    {
        public IGameObject Create(IGameObject gameObject)
        {
            if (gameObject is not UnityGameObject unityGameObject)
                return null;
            
            UnityEngine.GameObject newGameObject = UnityEngine.Object.Instantiate(unityGameObject.Original);

            return (UnityGameObject)UnityMethods.Upsert(newGameObject);
        }
    }
}
