using IceFebruary;
using IceFebruary.Render;
using IceFebruary.Space;
using IceFebruary.Space.Vector2Provider;

public sealed class MouseVector2Provider : IVector2Provider
{
    private readonly IInputProvider _inputProvider;
    public MouseVector2Provider(IInputProvider inputProvider, ICamera camera)
    {
        _inputProvider = inputProvider;
    }
    public bool TryGet(out Vector2 point)
    {
        bool hasValue = _inputProvider.Active();

        point = hasValue ? _inputProvider.MousePosition : default;

        return hasValue;
    }
}
