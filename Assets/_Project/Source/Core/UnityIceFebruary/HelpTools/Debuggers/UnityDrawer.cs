#if UNITY_EDITOR
namespace UnityIceFebruary.HelpTools.Debuggers
{
    using IceFebruary.Space;
    using IceFebruary.Shapes;

    public static class UnityDrawer
    {
        private const float StandartShowDurationTime = 0.1f;
        private static readonly Vector2[] _circlePositions = new Vector2[]
        {
            new(1f, 0f),
            new(0.98481f, 0.17365f),
            new(0.93969f, 0.34202f),
            new(0.86603f, 0.5f),
            new(0.76604f, 0.64279f),
            new(0.64279f, 0.76604f),
            new(0.5f, 0.86603f),
            new(0.34202f, 0.93969f),
            new(0.17365f, 0.98481f),
            new(0f, 1f),
            new(-0.17365f, 0.98481f),
            new(-0.34202f, 0.93969f),
            new(-0.5f, 0.86603f),
            new(-0.64279f, 0.76604f),
            new(-0.76604f, 0.64279f),
            new(-0.86603f, 0.5f),
            new(-0.93969f, 0.34202f),
            new(-0.98481f, 0.17365f),
            new(-1f, 0f),
            new(-0.98481f, -0.17365f),
            new(-0.93969f, -0.34202f),
            new(-0.86603f, -0.5f),
            new(-0.76604f, -0.64279f),
            new(-0.64279f, -0.76604f),
            new(-0.5f, -0.86603f),
            new(-0.34202f, -0.93969f),
            new(-0.17365f, -0.98481f),
            new(0f, -1f),
            new(0.17365f, -0.98481f),
            new(0.34202f, -0.93969f),
            new(0.5f, -0.86603f),
            new(0.64279f, -0.76604f),
            new(0.76604f, -0.64279f),
            new(0.86603f, -0.5f),
            new(0.93969f, -0.34202f),
            new(0.98481f, -0.17365f),
            new(1f, 0f)
        };
        private static readonly float _standartXOneSize = 0.05f;
        private static readonly Vector2 _topLeftX = _standartXOneSize * Vector2.TopLeft;
        private static readonly Vector2 _topRightX = _standartXOneSize * Vector2.TopRight;
        private static readonly Vector2 _bottomRightX = _standartXOneSize * Vector2.BottomRight;
        private static readonly Vector2 _bottomLeftX = _standartXOneSize * Vector2.BottomLeft;
        public static void DrawRectangle(Vector2 position, Vector2 size, float duration = StandartShowDurationTime) => DrawRectangle(position, size, Rotor2.Default, duration);
        public static void DrawRectangle(Vector2 position, Vector2 size, Rotor2 rotation, float duration = StandartShowDurationTime)
        {
            Vector2 halfSize = size * 0.5f;

            Vector2 topLeft = position + rotation * (Vector2.TopLeft * halfSize);
            Vector2 topRight = position + rotation * (Vector2.TopRight * halfSize);
            Vector2 bottomRight = position + rotation * (Vector2.BottomRight * halfSize);
            Vector2 bottomLeft = position + rotation * (Vector2.BottomLeft * halfSize);

            Debugger.DrawLine(topLeft, topRight, duration);
            Debugger.DrawLine(topRight, bottomRight, duration);
            Debugger.DrawLine(bottomRight, bottomLeft, duration);
            Debugger.DrawLine(bottomLeft, topLeft, duration);
        }
        public static void DrawCircle(Vector2 position, float radius, float duration = StandartShowDurationTime)
        {
            for (int index = 1; index < _circlePositions.Length; index++)
                Debugger.DrawLine(position + _circlePositions[index - 1] * radius, position + _circlePositions[index] * radius, duration);
        }
        public static void DrawX(Vector2 position, float duration = StandartShowDurationTime)
        {
            Debugger.DrawLine(_topLeftX + position, _bottomRightX + position, duration);
            Debugger.DrawLine(_topRightX + position, _bottomLeftX + position, duration);
        }
        public static void DrawShape(IShape shape, Vector2 position, float duration = StandartShowDurationTime) => DrawShape(shape, position, Rotor2.Default, duration);
        public static void DrawShape(IShape shape, Vector2 position, Rotor2 rotation, float duration = StandartShowDurationTime)
        {
            switch (shape)
            {
                case Rectangle rectangle:
                    DrawRectangle(position, rectangle.Size, rotation, duration);
                    break;
                case Circle circle:
                    DrawCircle(position, circle.Radius, duration);
                    break;
                case Dot:
                    DrawX(position, duration);
                    break;
                default:
                    UnityDrawerDebugger.WarnAboutUnkonwnShape();
                    break;
            }
        }
    }
}
#endif
