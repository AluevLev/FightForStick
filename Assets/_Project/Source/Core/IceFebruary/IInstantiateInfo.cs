namespace IceFebruary
{
    public interface IInstantiateInfo<out T> where T : struct
    {
        T ToPoco();
    }
}
