using System.Collections;

namespace Задание_2
{
    public class DynamicArray<T> : IEnumerable<T>, IDisposable
    {
        private T[] _array;
        public int _length = 0;

        private bool _disposed = false;

        const int DEFAULT_LENGTH = 8;

        public delegate void EventHandler(Object sender, DynamicArrayEventArgs e);
        public event EventHandler ResizeCapacity;

        public DynamicArray()
        {
            _array = new T[DEFAULT_LENGTH];
            Length = 0;
        }

        public DynamicArray(int size)
        {
            _array = new T[size];
            Length = 0;
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            _array = new T[GetLengthOfCollection(collection)];

            int index = 0;
            foreach (T element in collection)
            {
                _array[index] = element;
                index++;
            }

            Length = index;
        }

        public void Add(T value)
        {
            ResizingOfArray(Length + 1);
            _array[Length] = value;
            Length++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            ResizingOfArray(Length + GetLengthOfCollection(collection));

            int index = Length;
            foreach (T element in collection)
            {
                _array[index] = element;
                index++;
            }

            Length = index;
        }

        public void Remove(T value, Func<T, T, bool>? equals = null)
        {
            int index = 0;

            int countValueInArray = 0;

            if (equals is null)
            {
                foreach (T element in _array)
                {
                    if (value is not null && !value.Equals(element))
                    {
                        _array[index] = element;
                        index++;
                        countValueInArray++;
                    }
                }
            }
            else
            {
                foreach (T element in _array)
                {
                    if (!equals(value, element))
                    {
                        _array[index] = element;
                        index++;
                        countValueInArray++;
                    }
                }
            }

            Length -= countValueInArray;
        }

        public void Insert(T value, int position)
        {
            CheckIndex(position);
            ResizingOfArray(Length + 1);

            T thisElement = value;
            for (int i = position; i < Length; i++)
            {
                T nextElement = _array[i];
                _array[i] = thisElement;
                thisElement = nextElement;
            }
            _array[Length] = thisElement;

            Length++;
        }

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                _length = value;
            }
        }

        private int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DynamicArrayEnumerator<T>(_array, Length);
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);
                return _array[index];
            }
            set
            {
                CheckIndex(index);
                _array[index] = value;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not DynamicArray<T> na || na.Length != Length)
            {
                return false;
            }

            if(na.GetHashCode() == obj.GetHashCode())
            {
                //for (int i = 0; i < Length; i++)
                //{
                //    if (!na._array[i].Equals(_array[i]))
                //    {
                //        return false;
                //    }
                //}
                return true;
            }
            else { return false; }
        }
        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach (T element in _array)
            {
                hashCode += element.GetHashCode();
            }

            return hashCode;
        }

        public static explicit operator T[](DynamicArray<T> array)
        {
            T[] array_tmp = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array_tmp[i] = array[i];
            }
            return array_tmp;
        }


        public static implicit operator DynamicArray<T>(T[] array) => new(array);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                foreach (T element in _array)
                {
                    if (element is IDisposable)
                    {
                        ((IDisposable)element).Dispose();
                    }
                }
                ResizeCapacity(this, new DynamicArrayEventArgs(0, Capacity));
                Array.Clear(_array);
                Length = 0;
            }
            _disposed = true;
        }

        ~DynamicArray()
        {
            Dispose(false);
        }

        private void ResizingOfArray(int newLength)
        {
            if (Capacity < newLength)
            {
                int tmpCapacity = Capacity;
                while (tmpCapacity < newLength)
                {
                    tmpCapacity *= 2;
                }
                T[] tmp_arr = new T[tmpCapacity];

                for (int i = 0; i < Length; i++)
                {
                    tmp_arr[i] = _array[i];
                }

                ResizeCapacity?.Invoke(this, new DynamicArrayEventArgs(tmpCapacity, Capacity));
                _array = tmp_arr;
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private int GetLengthOfCollection(IEnumerable<T> collection)
        {
            int lengthCollection = 0;
            foreach (T element in collection)
            {
                lengthCollection++;
            }
            return lengthCollection;
        }
    }
}