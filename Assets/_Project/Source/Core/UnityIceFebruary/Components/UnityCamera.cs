namespace UnityIceFebruary.Components
{
    using IceFebruary.Proxy;
    using IceFebruary.Render;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using Camera = UnityEngine.Camera;

    public sealed class UnityCamera : UnityBaseEntity<Camera>, ICamera
    {
        [FieldProxy(typeof(ICamera))]
        public UnityCamera(Camera camera) : base(camera) { }
        public Vector2 ScreenToWorldPoint(Vector2 onScreenPosition) => Original.ScreenToWorldPoint(onScreenPosition.ToUnity()).ToIce();
        public Vector2 WorldToScreenPoint(Vector2 inWorldPosition) => Original.WorldToScreenPoint(inWorldPosition.ToUnity()).ToIce();
    }
}
