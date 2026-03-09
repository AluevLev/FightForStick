using IceFebruary.Space.PointProvider;
using IceFebruary.Space;
using UnityIceFebruary.Adaptation;
using IceFebruary.Physics;
using IceFebruary.Shapes;

public class AreaCaster<T> : IAreaCaster where T : struct, IShape
{
    private readonly IPhysics2D _physics;
    private readonly IPointProvider _position;
    private readonly IPointProvider _angleDirection;
    private readonly IShape _shape;
    private readonly UnityEngine.ContactFilter2D _contactFilter2D;
    private readonly UnityEngine.RaycastHit2D[] _singleHitBuffer = new UnityEngine.RaycastHit2D[1];

    public AreaCaster(T shape, IPointProvider position = null, IPointProvider angleDirection = null, UnityEngine.ContactFilter2D contactFilter = default)
    {
        _shape = shape;
        _position = position;
        _angleDirection = angleDirection;
        _contactFilter2D = contactFilter;
    }
    public bool Cast()
    {
        int count = 0;
        /*
        if (_position.TryGetPointSafe(out Vector2 position) && _angleDirection.TryGetPointSafe(out Vector2 angleDirection))
            count = Physics2D.BoxCast(position.ToUnity2D(), _shape.ToUnity2D(), angleDirection.Angle, UnityEngine.Vector2.zero, _contactFilter2D, _singleHitBuffer);

        if (_position.TryGetPointSafe(out Vector2 position) && _angleDirection.TryGetPointSafe(out Vector2 angleDirection))
        {
            count = _physics.Overlap(_shape);
        }

        _physics.Overlap();
        */

        return count > 0;
    }
}
