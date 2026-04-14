namespace IceFebruary.Time
{
    public interface ITime
    {
        float FixedFrameRate { get; set; }
        void LaunchIFrame(Entity<IFrame> frame);
        void LaunchIFixedFrame(Entity<IFixedFrame> fixedFrame);
    }
}
