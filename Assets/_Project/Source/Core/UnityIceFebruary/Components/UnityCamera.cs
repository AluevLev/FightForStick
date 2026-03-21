namespace UnityIceFebruary.Components
{
    using IceFebruary.Space;
    using IceFebruary.Render;
    using UnityIceFebruary.Adaptation;
    using UnityIceFebruary.Components;
    using UnityIceFebruary.AutoGeneration.Match;

    using Camera = UnityEngine.Camera;

    [UnityAnalog(typeof(Camera))]
    public class UnityCamera : ICamera
    {
        public Camera Camera { get; private init; }
        public UnityCamera(Camera camera)
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
