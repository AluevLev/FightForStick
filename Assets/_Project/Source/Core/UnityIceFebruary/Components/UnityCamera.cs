namespace UnityIceFebruary.Components
{
    using IceFebruary.Space;
    using IceFebruary.Render;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.Components;
    using UnityIceFebruary.AutoGeneration;

    using Camera = UnityEngine.Camera;

    [UnityAnalog(typeof(Camera))]
    public sealed class UnityCamera : UnityBaseEntity<Camera>, ICamera
    {
        public UnityCamera(Camera camera) : base(camera) { }
        public Vector2 ScreenToWorldPoint(Vector2 onScreenPosition) => Original.ScreenToWorldPoint(onScreenPosition.ToUnity()).ToIce();
        public Vector2 WorldToScreenPoint(Vector2 inWorldPosition) => Original.WorldToScreenPoint(inWorldPosition.ToUnity()).ToIce();
    }
}
