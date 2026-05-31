namespace UnityIceFebruary
{
    using IceFebruary;
    using IceFebruary.Physics;
    using IceFebruary.Shapes;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    using static UnityEngine.Physics2D;
    using UnityCollider2D = UnityEngine.Collider2D;
    using UnityContactFilter2D = UnityEngine.ContactFilter2D;
    using UnityVector2 = UnityEngine.Vector2;

    public sealed class UnityPhysics2D : BaseEntity, IPhysics2D
    {
        private UnityCollider2D[] _collidersBuffer;

        private IShape _shape;
        private UnityVector2 _position;
        private UnityContactFilter2D _contactFilter2D;
        private float _angle;

        private UnityVector2 _rectangleSize;

        private float _circleRadius;
        public UnityPhysics2D(int collidersBufferLength = 64)
        {
            _collidersBuffer = new UnityCollider2D[collidersBufferLength.ClampMin(4)];
        }
        public int Overlap(IShape shape, Vector2 position, Rotor2? rotor = null, ContactFilter2D? contactFilter2D = null, Component<ICollider2D>[] result = null)
        {
            if (shape == null)
                return 0;

            FillData(shape, position, rotor, contactFilter2D, result);

            int count = Overlap();

            if (result != null)
                FillArray(result, count);

            return count;
        }
        private void FillArray(Component<ICollider2D>[] result, int count)
        {
            for (int index = 0; index < Math.Min(result.Length, count); index++)
            {
                UnityCollider2D unityCollider2D = _collidersBuffer[index];

                ICollider2D collider2D = (ICollider2D)UnityMethods.Upsert(unityCollider2D);
                IGameObject gameObject = (IGameObject)UnityMethods.Upsert(unityCollider2D.gameObject);
                result[index] = new(collider2D, gameObject);
            }
        }
        private void FillData(IShape shape, Vector2 position, Rotor2? rotor = null, ContactFilter2D? contactFilter2D = null, Component<ICollider2D>[] result = null)
        {
            _shape = shape;
            _position = position.ToUnity();
            _contactFilter2D = (contactFilter2D ?? ContactFilter2D.Default).ToUnity();
            _angle = (rotor ?? Rotor2.Default).ToAngle(false);

            switch (shape)
            {
                case Circle circle:
                    _circleRadius = circle.Radius;
                    break;

                case Rectangle rectangle:
                    _rectangleSize = rectangle.Size.ToUnity();
                    break;
            }
        }
        private int Overlap()
        {
            int count = UnityOverlap();

            if (count > _collidersBuffer.Length)
            {
                int power = Math.GetPower2WithReserve(count);
                _collidersBuffer = new UnityCollider2D[1 << power];

                return Overlap();
            }

            return count;
        }
        private int UnityOverlap() => _shape switch
        {
            Dot => OverlapPoint(_position, _contactFilter2D, _collidersBuffer),
            Circle => OverlapCircle(_position, _circleRadius, _contactFilter2D, _collidersBuffer),
            Rectangle => OverlapBox(_position, _rectangleSize, _angle, _contactFilter2D, _collidersBuffer),
            _ => 0
        };
    }
}
