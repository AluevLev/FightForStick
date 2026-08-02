public interface ISettableUp<T> where T : struct
{
    void SetUp(T config);
}
public interface ISettableUp<T, TRet> where T : struct
{
    TRet SetUp(T config);
}