namespace IceFebruary.Space.Follow
{
    public interface ITargetPossessing<T>
    {
        void SetTarget(T target);
        void ResetTarget();
    }
}
