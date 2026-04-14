namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Collections;
    using IceFebruary.Time;
    using UnityEngine;

    public sealed class UnityTime //: ITime, IFrame, IFixedFrame
    {
        private readonly EntityFastArray<Entity<object>> _frameArray;
        private readonly EntityFastArray<Entity<object>> _fixedFrameArray;
        public UnityTime(int startArraySize = 2048)
        {
            _frameArray = new(startArraySize);
            _fixedFrameArray = new(startArraySize);
        }
        public float FixedFrameRate
        {
            get => Time.fixedDeltaTime;
            set => Time.fixedDeltaTime = value;
        }
        public void OnFrame()
        {
            //for (int index = 0; index < _frameArray.Length; index++)
                //if (_frameArray.TryGetEntity(index, out IFrame inner))
                //    inner.OnFrame();
        }
        public void OnFixedFrame()
        {
            //for (int index = 0; index < _fixedFrameArray.Length; index++)
                //if (_fixedFrameArray.TryGetEntity(index, out IFixedFrame inner))
                //    inner.OnFixedFrame();
        }
        public void LaunchIFrame(Entity<object> entity)
        {
            //if (entity.TryGetInner(out _))
            //    _frameArray.Register(entity);
        }
        public void LaunchIFixedFrame(Entity<object> entity)
        {
            //if (entity.TryGetInner(out _))
            //    _fixedFrameArray.Register(entity);
        }
    }
}
