using System.Collections;

namespace Задание_2
{
    public class DynamicArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int _length;
        private int _position = -1;

        public DynamicArrayEnumerator(T[] array, int length)
        {
            _array = array;
            _length = length;
        }

        public T Current
        {
            get
            {
                if (_position != -1 && _position < _array.Length)
                {
                    return _array[_position];
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _length;
        }

        object IEnumerator.Current => Current;

        public void Reset()
        {
            _position = -1;
        }

        public void Dispose() { }
    }
}

