namespace UnityIceFebruary.Components
{
    using IceFebruary;

    public static class UnityExtensions
    {
        public static IGameObject ToIce(this UnityEngine.GameObject gameObject) => UnityMethods.Upsert(gameObject);
        public static IComponent ToIce<T>(this T component) where T : UnityEngine.Component => UnityMethods.Upsert(component);
    }
}
