namespace IceFebruary.Space
{
    public static class UniversalVector2Extensions
    {
        public static Vector2 GetVector(this float angle) => Vector2.GetVectorByAngle(angle);
        public static Vector2 Rotate(this Vector2 v, float angle) => Vector2.Rotate(v, angle);
        public static Vector2 DirectionTo(this Vector2 from, Vector2 to) => Vector2.DirectionTo(from, to);
    }
}
