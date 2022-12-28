using System;

namespace Задание_2
{
    public class DynamicArrayEventArgs : EventArgs
    {
        public DynamicArrayEventArgs(int newCapacity, int oldCapacity)
        {
            NewCapacity = newCapacity;
            OldCapacity = oldCapacity;
        }

        public int OldCapacity { get; private set; }
        public int NewCapacity { get; private set; }
    }
}

