namespace LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }
            public T Value { get; private set; }

            public QueueNode<T> PrevNode { get; set; }

            public QueueNode<T> NextNode { get; set; }
        }

        private QueueNode<T> firstNode;

        private QueueNode<T> lastNode;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.firstNode = this.lastNode = new QueueNode<T>(element);
            }
            else
            {
                var newNode = new QueueNode<T>(element);
                this.lastNode.NextNode = newNode;
                newNode.PrevNode = this.lastNode;
                this.lastNode = newNode;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Queue is Empty.");
            }
            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            if (this.firstNode != null)
            {
                this.firstNode.PrevNode = null;
            }
            else
            {
                this.lastNode = null;
            }

            this.Count--;
            return element;
        }

        public T[] ToArray()
        {
           T[] array = new T[this.Count];
            var currentNode = this.firstNode;
            int index = 0;
            while (currentNode != null)
            {
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return array;
        }
    }
}
