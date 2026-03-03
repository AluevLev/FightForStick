namespace February.Space
{
    public static class UniversalVector2Extensions
    {
        public static UniVector2 GetVector(this float angle) => UniVector2.GetVectorByAngle(angle);
        public static UniVector2 Rotate(this UniVector2 v, float angle) => UniVector2.Rotate(v, angle);
        public static UniVector2 DirectionTo(this UniVector2 from, UniVector2 to) => UniVector2.DirectionTo(from, to);
    }
}
