namespace UnityIceFebruary.Components
{
    using IceFebruary;
    using IceFebruary.Components;
    using IceFebruary.Space;
    using UnityIceFebruary.Adaptation;

    public class UnityCamera : ICamera
    {
        private readonly UnityEngine.Camera _camera;
        public bool Enabled
        {
            get => _camera.enabled;
            set => _camera.enabled = value;
        }
        public IGameObject GameObject { get; init; }
        public UnityCamera(UnityEngine.Camera camera)
        {
            _camera = camera;
            GameObject = new UnityGameObject(camera.gameObject);
        }
        public Vector2 ScreenToWorldPoint(Vector2 onScreenPosition) => _camera.ScreenToWorldPoint(onScreenPosition.ToUnity3D()).ToUniversal();
        public Vector2 WorldToScreenPoint(Vector2 inWorldPosition) => _camera.WorldToScreenPoint(inWorldPosition.ToUnity3D()).ToUniversal();
    }
}
