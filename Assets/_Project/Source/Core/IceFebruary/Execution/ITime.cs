namespace IceFebruary.Time
{
    public interface ITime : IFrame, IFixedFrame
    {
        float FixedFrameRate { get; set; }
        void LaunchIFrame(IFrame frame);
        void LaunchIFixedFrame(IFixedFrame fixedFrame);
    }
}
