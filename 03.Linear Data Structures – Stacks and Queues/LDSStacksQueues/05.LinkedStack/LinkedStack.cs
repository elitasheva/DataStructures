namespace LinkedStackImplementation
{
    using System;

    public class LinkedStack<T>
    {
        private class Node<T>
        {
            public Node(T value, Node<T> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; private set; }

            public Node<T> NextNode { get; set; }

        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T value)
        {
            this.firstNode = new Node<T>(value, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            var element = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
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
