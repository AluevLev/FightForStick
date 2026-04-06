namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    public sealed class EntityFastArray<T> where T : class
    {
        private IEntity<T>[] _entities;
        private int _length;
        private readonly Stack<int> _freeIndexes = new();
        public int Length => _length;
        public EntityFastArray(int startLength)
        {
            _length = Math.Clamp(startLength, 4, int.MaxValue);
            _entities = new IEntity<T>[_length];

            for (int index = 0; index < _length; index++)
                _freeIndexes.Push(index);
        }
        public void Register(IEntity<T> obj)
        {
            if (!obj.TryGetInner(out _))
                return;

            if (_freeIndexes.Count == 0)
                for (int entityIndex = 0; entityIndex < _length; entityIndex++)
                    if (!_entities[entityIndex].TryGetInner(out _))
                        _freeIndexes.Push(entityIndex);

            if (_freeIndexes.Count == 0)
            {
                int doubledLength = _length * 2;

                System.Array.Resize(ref _entities, doubledLength);

                for (int index = _length; index < doubledLength; index++)
                    _freeIndexes.Push(index);

                _length = doubledLength;
            }

            _entities[_freeIndexes.Pop()] = obj;
        }
        public bool TryGetEntity(int index, out T inner)
        {
            inner = null;

            if (!index.InBounds(0, _length))
                return false;

            ref IEntity<T> entity = ref _entities[index];

            if (entity == null)
                return false;

            if (entity.Disposed)
            {
                entity = null;
                _freeIndexes.Push(index);
                return false;
            }

            inner = entity.RawInner;
            return entity.Enabled;
        }
    }
}
