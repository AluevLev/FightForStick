namespace IceFebruary.Time
{
    public sealed class Timer
    {
        private readonly ITime _time;
        private readonly float _cooldown;
        private float _endTime;
        public bool InCoolDown => _endTime > _time.CurrentTime;
        public Timer(ITime time, float cooldown)
        {
            _time = time;
            _cooldown = cooldown;
        }
        public void SetCooldown() => _endTime = _time.CurrentTime + _cooldown;
        public void ResetCooldown() => _endTime = -1f;
    }
}
