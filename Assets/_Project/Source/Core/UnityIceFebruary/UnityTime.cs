namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Collections;
    using IceFebruary.Time;
    using UnityEngine;

    public sealed class UnityTime : BaseEntity, ITime, IFrame, IFixedFrame
    {
        private readonly EntityFastArray<IFrame> _frameArray;
        private readonly EntityFastArray<IFixedFrame> _fixedFrameArray;
        public UnityTime(int startArraySize = 128)
        {
            _frameArray = new(startArraySize);
            _fixedFrameArray = new(startArraySize);
        }
        public float FixedFrameRate
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }
        public void OnFrame(float frameLength)
        {
            for (int index = 0; index < _frameArray.Length; index++)
            {
                IFrame frame = _frameArray.Entities[index];

                if (frame.Exists() && frame.Enabled)
                    frame.OnFrame(frameLength);
            }
        }
        public void OnFixedFrame()
        {
            for (int index = 0; index < _fixedFrameArray.Length; index++)
            {
                IFixedFrame fixedFrame = _fixedFrameArray.Entities[index];

                if (fixedFrame.Exists() && fixedFrame.Enabled)
                    fixedFrame.OnFixedFrame();
            }
        }
        public void LaunchIFrame(IFrame frame)
        {
            if (frame.Exists())
                _frameArray.Register(frame);
        }
        public void LaunchIFixedFrame(IFixedFrame fixedFrame)
        {
            if (fixedFrame.Exists())
                _fixedFrameArray.Register(fixedFrame);
        }
    }
}
