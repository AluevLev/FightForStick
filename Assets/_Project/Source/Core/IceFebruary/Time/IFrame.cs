namespace IceFebruary.Time
{
    public interface IFrame : IBaseEntity
    {
        void OnFrame(float frameLength);
    }
}
