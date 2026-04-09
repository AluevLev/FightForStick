namespace IceFebruary.Animation
{
    public interface IAnimator
    {
        T GetVariable<T>(int hash) where T : struct;
        void SetVariable<T>(int hash, T value) where T : struct;
        void SetTrigger(int hash);
    }
}
