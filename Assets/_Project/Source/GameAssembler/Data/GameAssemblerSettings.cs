using IceFebruary.Proxy;

public readonly struct GameAssemblerSettings
{
    public int StartTimeCyclesBufferLength { get; private init; }
    public int StartPhysicsCollidersBufferLength { get; private init; }

    [ScriptableObjectProxy]
    public GameAssemblerSettings(int startTimeCyclesBufferLength, int startPhysicsCollidersBufferLength)
    {
        StartTimeCyclesBufferLength = startTimeCyclesBufferLength;
        StartPhysicsCollidersBufferLength = startPhysicsCollidersBufferLength;
    }
}
