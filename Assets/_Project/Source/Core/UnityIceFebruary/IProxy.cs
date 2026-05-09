namespace UnityIceFebruary
{
    public interface IProxy<T> where T : struct
    {
        T ToPoco();
    }
}
