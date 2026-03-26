namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityIceFebruary.Components;

    public class UnityObjectManager : IObjectManager
    {
        public IGameObject Create(IGameObject gameObject)
        {
            if (gameObject is not UnityGameObject unityGameObject)
                return null;

            UnityEngine.GameObject newGameObject = UnityEngine.Object.Instantiate(unityGameObject.GameObject);

            return UnityMethods.Upsert(newGameObject);
        }
        public void Destroy(IGameObject gameObject)
        {
            if (gameObject is not UnityGameObject unityGameObject)
                return;

            UnityEngine.Object.Destroy(unityGameObject.GameObject);
            UnityMethods.Remove(gameObject);
            gameObject = null;
        }
        public void Destroy(IComponent component)
        {
            if (component is not IUnityAnalog unityComponent)
                return;

            UnityEngine.Object.Destroy(unityComponent.Original);
            UnityMethods.Remove(unityComponent);
            component = null;
        }
    }
}
