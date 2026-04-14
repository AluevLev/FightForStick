namespace UnityIceFebruary
{
    using IceFebruary;

    public sealed class UnityObjectManager : IObjectManager
    {
        /*
        public IDestroyable<IGameObject> Create(IGameObject gameObject)
        {
            if (gameObject is not UnityGameObject unityGameObject)
                return null;
            
            UnityEngine.GameObject newGameObject = UnityEngine.Object.Instantiate(unityGameObject.GameObject);

            return null;//new UnityToggleable<UnityGameObject>(UnityMethods.Upsert(newGameObject) as UnityGameObject); TODO
        }
        */
    }
}
