namespace UnityIceFebruary
{
    using IceFebruary.Time;
    using UnityEngine;

    public class UnityTime : ITime
    {
        private static readonly int _usualSizeOfMassive = 16384;
        private IFrame[] _frames = new IFrame[_usualSizeOfMassive];
        private int _index = 0;
        public float FixedFrameRate
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }
        public void OnFrame()
        {

        }
        public void OnFixedFrame()
        {

        }
        public void LaunchIFrame(IFrame frame)
        {

        }
        public void LaunchIFixedFrame(IFixedFrame frame)
        {

        }
    }
}
