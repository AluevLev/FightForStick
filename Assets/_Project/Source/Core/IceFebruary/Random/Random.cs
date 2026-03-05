namespace IceFebruary.Random
{
    using System;
    using System.Collections.Generic;
    using IceFebruary.Collections;

    public struct Random
    {
        private const float UintFloatMaxValue = uint.MaxValue;

        private uint _state;
        public uint State
        {
            readonly get => _state;
            set => _state = value;
        }
        public Random(uint state)
        {
            _state = state == 0 ? 1 : state;
        }
        private uint ChangeState()
        {
            _state ^= _state << 13;
            _state ^= _state >> 17;
            _state ^= _state << 5;

            return _state;
        }
        private uint RandomUnum(uint max) => ChangeState() % max;
        private float RandomFloat01() => ChangeState() / UintFloatMaxValue;
        private readonly void FixOrder<T>(ref T min, ref T max) where T : IComparable<T>
        {
            int sign = min.CompareTo(max);

            if (sign > 0)
                (min, max) = (max, min);
        }
        public int BetweenInt(int min, int max)
        {
            FixOrder(ref min, ref max);

            return min + (int)RandomUnum((uint)(max - min));
        }
        public float BetweenFloat(float min, float max)
        {
            FixOrder(ref min, ref max);

            return RandomFloat01() * (max - min) + min;
        }
        public bool FiftyFifty => (ChangeState() & 1) == 0;
        public float Percent => BetweenFloat(0f, 1f);
        public T InArray<T>(T[] array) => array.Exist() ? array[BetweenInt(0, array.Length)] : default;
        public T InList<T>(List<T> list) => list.Exist() ? list[BetweenInt(0, list.Count)] : default;
    }
}
