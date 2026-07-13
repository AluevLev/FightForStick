namespace IceFebruary.Time
{
    public interface ITime : IBaseEntity
    {
        float CurrentTime { get; }
        float FixedFrameRate { get; set; }
        void LaunchIFrame(IFrame frame);
        void LaunchIFixedFrame(IFixedFrame fixedFrame);
        void DoFrame(float frameLength);
        void DoFixedFrame();
    }
}
