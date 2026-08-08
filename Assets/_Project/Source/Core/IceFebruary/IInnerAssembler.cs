namespace IceFebruary
{
    using IceFebruary.Time;

    public interface IInnerAssembler
    {
        void Assemble();
        ITime Time { get; }
    }
}
