namespace UnityIceFebruary
{
    using UnityEngine;
    using IceFebruary.Time;
    using IceFebruary.Physics;
    using IceFebruary;
    using IceFebruary.Space.Vector2Provider;
    using IceFebruary.Render;

    public class GameAssembler : MonoBehaviour
    {
        [SerializeField] private int _startCyclesBufferSize = 128;
        [SerializeField] private int _overlapCollidersBufferLength = 64;
        [SerializeField] private GameInputAction _gameInputAction;
        [SerializeField] private Camera _unityCamera;

        private ITime _time;
        private IPhysics2D _physics2D;
        private IObjectManager _objectManager;

        private ICamera _camera;

        private IInputProvider _input;
        private IVector2Provider _cursor;

        private StickmanFactory _stickmanFactory;

        private void Awake()
        {
            _camera = (ICamera)UnityMethods.Upsert(_unityCamera);

            _time = new UnityTime(_startCyclesBufferSize);
            _physics2D = new UnityPhysics2D(_overlapCollidersBufferLength);
            _objectManager = new UnityObjectManager();

            _input = new UnityInputProvider(_gameInputAction);
            _cursor = new CursorPointProvider(_input, _camera);

            _stickmanFactory = new StickmanFactory(_time, _physics2D, _objectManager);
        }
        private void Update() => _time.DoFrame(Time.deltaTime);
        private void FixedUpdate() => _time.DoFixedFrame();
    }
}
