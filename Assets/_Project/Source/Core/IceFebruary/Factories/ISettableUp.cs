namespace IceFebruary.Factories
{
    public interface ISettableUp<T>
    {
        void SetUp(T config);
    }
    public interface ISettableUp<T, TRet>
    {
        TRet SetUp(T config);
    }
}
