namespace IceFebruary
{
    public interface IBaseEntity
    {
        bool Enabled { get; set; }
        bool Destroyed { get; }
        void Destroy();
    }
}