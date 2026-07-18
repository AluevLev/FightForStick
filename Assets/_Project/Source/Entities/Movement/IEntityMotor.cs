using IceFebruary.Space;
using IceFebruary;

public interface IEntityMotor : IBaseEntity
{
    void OpenHips();
    void CloseHips();
    void SetMinShins();
    void SetMaxShins();
    void ResetLegs();
    void ForcePush(Vector2 force);
    void ImpulsePush(Vector2 impulse);
}
