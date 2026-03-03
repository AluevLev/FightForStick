namespace February.Space.PointProvider
{
    using February.Proxy;
    using February.Space;

    [GenerateInterfaceProxy]
    public interface IPointProvider
    {
        /// <summary>
        /// ATTENTION: Use .TryGetPointSafe(), if you are unsure whether IPointProvider is null.
        /// </summary>
        bool TryGetPoint(out UniVector2 point);
    }
}
