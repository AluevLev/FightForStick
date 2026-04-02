namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    public class EntityFastArray<TEntity, TInner>
        where TEntity : class, IEntity<TInner>
        where TInner : class
    {
        private TEntity[] _entities;
        private int _length;
        private Stack<int> _freeIndexes = new();
        public int Length => _length;
        public EntityFastArray(int startLength)
        {
            _length = Math.Clamp(startLength, 4, int.MaxValue);
            _entities = new TEntity[_length];

            for (int index = 0; index < _length; index++)
                _freeIndexes.Push(index);
        }
        public void Register(TEntity obj)
        {
            if (!EntityHelper.EnsureAlive<TEntity, TInner>(ref obj, out _))
                return;

            if (_freeIndexes.Count == 0)
                for (int entityIndex = 0; entityIndex < _length; entityIndex++)
                    if (!EntityHelper.EnsureAlive<TEntity, TInner>(ref _entities[entityIndex], out _))
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
        public bool TryGetEntity(int index, out TInner inner)
        {
            if (!index.InBounds(0, _length))
            {
                inner = null;
                return false;
            }

            if (_entities[index] == null)
            {
                inner = null;
                return false;
            }

            if (!EntityHelper.EnsureAlive(ref _entities[index], out inner))
            {
                _freeIndexes.Push(index);
                return false;
            }

            return _entities[index].Enabled;
        }
    }
}
