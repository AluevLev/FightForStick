namespace February.Physics.Trigger
{
    using UnityEngine;
    using February.Space.PointProvider;
    using February.Space;
    using February.Adaptation;

    public class BoxCaster : IAreaCaster
    {
        private readonly IPointProvider _position;
        private readonly Vector2 _size;
        private readonly IPointProvider _angleDirection;
        private readonly ContactFilter2D _contactFilter2D;
        private readonly RaycastHit2D[] _singleHitBuffer = new RaycastHit2D[1];

        public BoxCaster(IPointProvider position, Vector2 size, IPointProvider angleDirection, ContactFilter2D contactFilter)
        {
            _position = position;
            _size = size;
            _angleDirection = angleDirection;
            _contactFilter2D = contactFilter;
        }
        public bool Cast()
        {
            int count = 0;

            if (_position.TryGetPointSafe(out UniVector2 position) && _angleDirection.TryGetPointSafe(out UniVector2 angleDirection))
                count = Physics2D.BoxCast(position.ToUnity2D(), _size, angleDirection.Angle, Vector2.zero, _contactFilter2D, _singleHitBuffer);

            return count > 0;
        }
    }
}
