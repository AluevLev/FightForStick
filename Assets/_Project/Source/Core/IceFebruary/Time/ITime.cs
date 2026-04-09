namespace IceFebruary.Time
{
    public interface ITime
    {
        float FixedFrameRate { get; set; }
        void LaunchIFrame(IEntity<IFrame> frame);
        void LaunchIFixedFrame(IEntity<IFixedFrame> fixedFrame);
    }
}
