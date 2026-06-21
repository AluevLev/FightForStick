namespace IceFebruary.Animation
{
    using IceFebruary.Proxy;

    [InterfaceProxy]
    public interface IAnimator : IBaseEntity //I'm sorry
    {
        int GetInt(int hash);
        void SetInt(int hash, int value);
        float GetFloat(int hash);
        void SetFloat(int hash, float value);
        bool GetBool(int hash);
        void SetBool(int hash, bool value);
        void SetTrigger(int hash);
    }
}
