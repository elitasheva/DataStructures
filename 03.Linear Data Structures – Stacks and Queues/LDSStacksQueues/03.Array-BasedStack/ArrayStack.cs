namespace Array_BasedStack
{
    using System;
    using System.Linq;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] array;
        private int capacity;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.capacity = capacity;
            this.array = new T[this.capacity];
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.array.Length)
            {
                this.Grow();
            }

            this.array[this.Count] = element;
            this.Count++;

        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

            this.Count--;
            var element = this.array[this.Count];
            this.array[this.Count] = default(T);
            return element;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                newArray[i] = this.array[this.Count - 1 - i];
            }
            return newArray;
        }

        private void Grow()
        {
            this.capacity = this.capacity * 2;
            T[] newArray = new T[this.capacity];
            Array.Copy(this.array, newArray, this.Count);
            this.array = newArray;
        }
    }
}
