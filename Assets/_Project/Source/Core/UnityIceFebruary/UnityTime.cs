namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Collections;
    using IceFebruary.Time;
    using UnityEngine;

    public class UnityTime : ITime
    {
        private EntityFastArray<IEntity<IFrame>, IFrame> _frameArray = new(1024);
        private EntityFastArray<IEntity<IFixedFrame>, IFixedFrame> _fixedFrameArray = new(1024);

        public float FixedFrameRate
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }

        public void OnFrame()
        {
            for (int index = 0; index < _frameArray.Length; index++)
                if (_frameArray.TryGetEntity(index, out IFrame inner))
                    inner.OnFrame();
        }

        public void OnFixedFrame()
        {
            for (int index = 0; index < _fixedFrameArray.Length; index++)
                if (_fixedFrameArray.TryGetEntity(index, out IFixedFrame inner))
                    inner.OnFixedFrame();
        }
        public void LaunchIFrame(IEntity<IFrame> entity)
        {
            if (entity.TryGetInner(out IFrame inner))
                _frameArray.Register(entity);
        }
        public void LaunchIFixedFrame(IEntity<IFixedFrame> entity)
        {
            if (entity.TryGetInner(out IFixedFrame inner))
                _fixedFrameArray.Register(entity);
        }
    }
}
