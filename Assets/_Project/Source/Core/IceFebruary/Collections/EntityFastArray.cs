namespace IceFebruary.Collections
{
    using System.Collections.Generic;

    public sealed class EntityFastArray<T> where T : class, IBaseEntity
    {
        private readonly Stack<int> _freeIndexes = new();
        private T[] _entities;
        public T[] Entities
        {
            get => _entities;
            private set => _entities = value;
        }
        public int Length { get; private set; }
        public EntityFastArray(int startLength)
        {
            Length = startLength.ClampMin(4);

            Entities = new T[Length];

            for (int index = 0; index < Length; index++)
                _freeIndexes.Push(index);
        }
        public void Register(T obj)
        {
            if (!obj.Exists())
                return;

            if (_freeIndexes.Count == 0)
                for (int entityIndex = 0; entityIndex < Length; entityIndex++)
                    if (!Entities[entityIndex].Exists())
                        _freeIndexes.Push(entityIndex);

            if (_freeIndexes.Count == 0)
            {
                int length = Length;
                int doubledLength = length * 2;

                System.Array.Resize(ref _entities, doubledLength);

                for (int index = length; index < doubledLength; index++)
                    _freeIndexes.Push(index);

                Length = doubledLength;
            }

            Entities[_freeIndexes.Pop()] = obj;
        }
    }
}
