namespace IceFebruary.Time
{
    public interface ITime : IBaseEntity
    {
        float FixedFrameRate { get; set; }
        void LaunchIFrame(IFrame frame);
        void LaunchIFixedFrame(IFixedFrame fixedFrame);
    }
}
