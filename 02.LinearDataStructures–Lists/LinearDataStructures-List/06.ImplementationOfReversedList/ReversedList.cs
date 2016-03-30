namespace ImplementationOfReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 8;
        private T[] array;
        private int capacity;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.capacity = capacity;
            this.array = new T[this.capacity];
        }

        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                var newCapacity = this.Capacity * 2;
                T[] newArray = new T[newCapacity];
                for (int i = 0; i < this.array.Length; i++)
                {
                    newArray[i] = this.array[i];
                }
                this.capacity = newCapacity;
                this.array = newArray;
            }

            this.array[this.Count] = item;
            this.Count++;
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int index]
        {

            get
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("Empty list.");
                }

                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Invalid index.");
                }

                return this.array[this.Count - 1 - index];
            }
        }

        public T Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty list.");
            }

            if (index < 0 || index > this.Count - 1)
            {
                throw new ArgumentOutOfRangeException("Invalid index.");
            }
            
            var element = this.array[this.Count - 1 - index];
            for (int i = this.Count-index-1; i < this.Count-1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.Count--;
            this.array[this.Count] = default(T);
            return element;
        }


        public IEnumerator<T> GetEnumerator()
        {
            int count = this.Count-1;
            while (count >= 0)
            {
                yield return this.array[count];
                count--;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
