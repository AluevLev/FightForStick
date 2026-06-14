namespace IceFebruary
{
    public interface IClassInfo<out T> where T : struct
    {
        T ToPoco();
    }
}
