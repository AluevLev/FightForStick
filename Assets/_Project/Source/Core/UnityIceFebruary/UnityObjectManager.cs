namespace UnityIceFebruary
{
    using IceFebruary;

    public class UnityObjectManager : IObjectManager
    {
        public IToggleable<IGameObject> Create(IGameObject gameObject)
        {
            if (gameObject is not UnityGameObject unityGameObject)
                return null;
            
            UnityEngine.GameObject newGameObject = UnityEngine.Object.Instantiate(unityGameObject.GameObject);

            return new UnityToggleable<UnityGameObject>(UnityMethods.Upsert(newGameObject) as UnityGameObject);
        }
    }
}
