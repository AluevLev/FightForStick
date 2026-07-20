namespace UnityIceFebruary.HelpTools.Debuggers
{
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public static class UnityDrawer
    {
        private const float StandartShowDurationTime = 0.1f;
        private static readonly Vector2[] _positionsForCircle = new Vector2[]
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
        private const float _standartXOneSize = 0.05f;
        public static void DrawRectangle(Vector2 position, Vector2 size, float duration = StandartShowDurationTime) => DrawRectangle(position, size, Rotor2.Default, duration);
        public static void DrawRectangle(Vector2 position, Vector2 size, Rotor2 rotation, float duration = StandartShowDurationTime)
        {
            Vector2 halfSize = size * 0.5f;

            Vector2 topLeft = position + rotation * new Vector2(-halfSize.X, halfSize.Y);
            Vector2 topRight = position + rotation * new Vector2(halfSize.X, halfSize.Y);
            Vector2 bottomRight = position + rotation * new Vector2(halfSize.X, -halfSize.Y);
            Vector2 bottomLeft = position + rotation * new Vector2(-halfSize.X, -halfSize.Y);

            DrawLine(topLeft, topRight, duration);
            DrawLine(topRight, bottomRight, duration);
            DrawLine(bottomRight, bottomLeft, duration);
            DrawLine(bottomLeft, topLeft, duration);
        }
        public static void DrawCircle(Vector2 position, float radius, float duration = StandartShowDurationTime)
        {
            for (int index = 1; index < _positionsForCircle.Length; index++)
                DrawLine(_positionsForCircle[index - 1], _positionsForCircle[index], duration);
        }
        public static void DrawX(Vector2 position, float duration = StandartShowDurationTime)
        {
            Vector2 topLeft = position + new Vector2(-_standartXOneSize, _standartXOneSize);
            Vector2 topRight = position + new Vector2(_standartXOneSize, _standartXOneSize);
            Vector2 bottomRight = position + new Vector2(_standartXOneSize, -_standartXOneSize);
            Vector2 bottomLeft = position + new Vector2(-_standartXOneSize, -_standartXOneSize);

            DrawLine(topLeft, bottomRight, duration);
            DrawLine(topRight, bottomLeft, duration);
        }
        public static void DrawLine(Vector2 a, Vector2 b, float duration = StandartShowDurationTime) => UnityEngine.Debug.DrawLine(a.ToUnity(), b.ToUnity(), UnityEngine.Color.green, duration);
    }
}
