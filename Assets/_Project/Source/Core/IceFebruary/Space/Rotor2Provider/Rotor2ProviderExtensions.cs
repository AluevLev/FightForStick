namespace IceFebruary.Space.Rotor2Provider
{
    public static class Rotor2ProviderExtensions
    {
        public static bool TryGetSafety(this IRotor2Provider rotor2Provider, out Rotor2 value)
        {
            if (rotor2Provider != null)
                return rotor2Provider.TryGet(out value);
            value = Rotor2.Default;
            return false;
        }
        public static Rotor2 GetSafety(this IRotor2Provider rotor2Provider)
        {
            rotor2Provider.TryGetSafety(out Rotor2 rotation);
            return rotation;
        }
    }
}
