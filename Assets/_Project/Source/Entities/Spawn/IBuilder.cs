using IceFebruary;

public interface IBuilder<T> where T : struct
{
    void SetConfig(T config);
}
