namespace IceFebruary.Collections
{
    using System;

    public class AutoExpandableArray<T>
    {
        private T[] _objects;
        private int _length;
        private int _currentIndex;
        public AutoExpandableArray(int startLength)
        {
            _length = startLength > 0 ? startLength : 4;
            _objects = new T[_length];
        }
        public void Register(T obj)
        {
            if (obj == null)
                return;

            if (_currentIndex >= _length)
            {
                _length *= 2;
                Array.Resize(ref _objects, _length);
            }

            _objects[_currentIndex] = obj;

            _currentIndex++;
        }
        public ReadOnlySpan<T> AsSpan() => _objects.AsSpan(0, _currentIndex);
    }
}
