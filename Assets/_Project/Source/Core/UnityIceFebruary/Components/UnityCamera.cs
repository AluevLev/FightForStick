namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Components;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;
    using UnityEngine;

    public class UnityCamera : ITogglable, ICamera
    {
        private readonly Camera _camera;
        public bool Enabled { get; set; }
        public UnityCamera(Camera camera)
        {
            _camera = camera;
        }
        public IceFebruary.Space.Vector2 ScreenToWorldPoint(IceFebruary.Space.Vector2 onScreenPosition) => _camera.ScreenToWorldPoint(onScreenPosition.ToUnity3D()).ToUniversal();
        public IceFebruary.Space.Vector2 WorldToScreenPoint(IceFebruary.Space.Vector2 inWorldPosition) => _camera.WorldToScreenPoint(inWorldPosition.ToUnity3D()).ToUniversal();
    }
}
