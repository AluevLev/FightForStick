using UnityEngine;

public static class MathExtensions2D
{
    public static Vector2 Rotate(this Vector2 vector, float angle)
    {
        float rad = Mathf.Deg2Rad * angle;
        
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);

        float x = vector.x;
        float y = vector.y;

        return new(x * cos - y * sin, x * sin + y * cos);
    }
    public static Vector2 DirectionTo(this Vector2 from, Vector2 to) => (to - from).normalized;
    public static float GetAngle(this Vector2 vector) => Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    public static Vector2 GetVector(this float angle) => Vector2.right.Rotate(angle);
}
