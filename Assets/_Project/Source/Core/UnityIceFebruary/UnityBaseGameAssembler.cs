namespace UnityIceFebruary
{
    using IceFebruary;
    using UnityEngine;

    public abstract class UnityBaseGameAssembler : MonoBehaviour
    {
        protected IInnerAssembler InnerAssembler
        {
            set
            {
                if (_innerAssembler != null || value == null)
                    return;

                _innerAssembler = value;
                _innerAssembler.Assemble();
            }
        }
        private IInnerAssembler _innerAssembler;
        private bool _isAssembled;
        public void Assemble()
        {
            if (_isAssembled)
                return;

            _isAssembled = true;

            Assembling();
        }
        protected abstract void Assembling();
        public void Disassemble()
        {
            OnDestroy();

            Destroy(gameObject);
        }
        private void OnDestroy() => InnerAssembler = null;
        private void Update() => _innerAssembler.Time.DoFrame(Time.deltaTime);
        private void FixedUpdate() => _innerAssembler.Time.DoFixedFrame();
    }
}
