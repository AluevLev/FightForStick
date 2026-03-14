namespace UnityIceFebruary.Components
{
    using IceFebruary.Space;
    using IceFebruary.Render;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.Components;

    public class UnityCamera : ICamera
    {
        public UnityEngine.Camera Camera { get; init; }
        public UnityCamera(UnityEngine.Camera camera)
        {
            Camera = camera;
        }
        public bool Enabled
        {
            get => Camera.enabled;
            set => Camera.enabled = value;
        }
        public Vector2 ScreenToWorldPoint(Vector2 onScreenPosition) => Camera.ScreenToWorldPoint(onScreenPosition.ToUnity3D()).ToIce();
        public Vector2 WorldToScreenPoint(Vector2 inWorldPosition) => Camera.WorldToScreenPoint(inWorldPosition.ToUnity3D()).ToIce();
    }
}
