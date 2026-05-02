namespace IceFebruary.Space.AngleProvider
{
    public static class AngleProviderExtensions
    {
        public static bool TryGetAngleSafe(this IAngleProvider angleProvider, out Rotor2 angle)
        {
            if (angleProvider != null)
                return angleProvider.TryGetAngle(out angle);
            angle = default;
            return false;
        }
    }
}